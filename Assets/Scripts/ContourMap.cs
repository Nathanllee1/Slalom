using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class ContourMap
{
    //Creates contour map from Raw 16bpp heightmap data as Texture2D
    //Returns null on failure
    //If neither width nor height specified, then it's POT size will be guessed
    public static Texture2D FromRawHeightmap16bpp(string fileName, int width = 0, int height = 0)
    {
        if (!File.Exists(fileName))
        {
            Debug.Log("Heightmap not found " + fileName);
            return null;
        }

        //dimensions
        int _width = width;
        int _height = height;

        Color32 bandColor = new Color32(255, 255, 255, 255);
        Color32 bkgColor = new Color32(0, 0, 0, 0);

        //Output
        Texture2D topoMap;

        //Read raw 16bit heightmap
        byte[] rawBytes = System.IO.File.ReadAllBytes(fileName);
        short[] rawImage = new short[rawBytes.Length / 2];

        //Create slice buffer
        bool[] slice = new bool[rawImage.Length];

        //Convert to bytes to short
        Buffer.BlockCopy(rawBytes, 0, rawImage, 0, rawBytes.Length);

        //Create Texture2D with estimated or specified width
        if (_width == 0 || _height == 0)
        {
            _width = (int)Math.Sqrt(rawImage.Length); //Estimated width/height
            _height = _width;
            topoMap = new Texture2D(_width, _height);
        }
        else
        {
            topoMap = new Texture2D(_width, _height);
        }

        topoMap.anisoLevel = 16;

        //Set background
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                topoMap.SetPixel(x, y, bkgColor);
            }
        }

        //Initial Min/Max values for signed 16bit value
        int minHeight = 32767;
        int maxHeight = -32767;

        //Find lowest and highest points
        for (int i = 0; i < rawImage.Length; i++)
        {
            if (rawImage[i] < minHeight)
            {
                minHeight = rawImage[i];
            }
            if (rawImage[i] > maxHeight)
            {
                maxHeight = rawImage[i];
            }
        }

        Debug.Log("Min: " + minHeight.ToString() + ", Max: " + maxHeight.ToString());

        //Create height band list
        int bandDistance = maxHeight / 12; //Number of height bands to create

        List<int> bands = new List<int>();

        //Get ranges
        int r = minHeight + bandDistance;
        while (r < maxHeight)
        {
            bands.Add(r);
            r += bandDistance;
        }

        //Draw bands
        for (int b = 0; b < bands.Count; b++)
        {

            //Get Slice
            for (int i = 0; i < rawImage.Length; i++)
            {
                if (rawImage[i] >= bands[b])
                {
                    slice[i] = true;
                }
                else
                {
                    slice[i] = false;
                }
            }

            //Detect edges on slice and write to output
            for (int y = 1; y < _height - 1; y++)
            {
                for (int x = 1; x < _width - 1; x++)
                {
                    if (slice[y * _width + x] == true)
                    {
                        if (slice[y * _width + (x - 1)] == false || slice[y * _width + (x + 1)] == false || slice[(y - 1) * _width + x] == false || slice[(y + 1) * _width + x] == false)
                        {
                            topoMap.SetPixel(x, y, bandColor);
                        }
                    }
                }
            }

        }

        topoMap.Apply();

        //Return result
        return topoMap;
    }
}