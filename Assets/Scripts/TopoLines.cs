using UnityEngine;
using System.Collections;

public class TopoLines : MonoBehaviour
{
    public string heightmapPath = "/Users/dave/desktop/terrain.raw";

    public Texture2D topoMap;

    public Material outputMaterial;

    void Start()
    {
        topoMap = ContourMap.FromRawHeightmap16bpp(heightmapPath);

        if (topoMap == null)
        {
            Debug.Log("Creation of topomap failed.");
        }
        else
        {
            Debug.Log("Creation of topomap was successful.");
        }

        if (outputMaterial != null)
        {
            outputMaterial.mainTexture = topoMap;
        }
    }
}
