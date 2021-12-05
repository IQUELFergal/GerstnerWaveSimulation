using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    //Public Properties
    public int Dimension = 100;

    //Mesh
    protected Material Material;
    protected Mesh Mesh;
    public Vector4[] waves = new Vector4[3];
    public Vector4[] wavesDefault = new Vector4[3];

    // Start is called before the first frame update
    void Start()
    {
        //Mesh Setup
        Mesh = GetComponent<MeshFilter>().mesh;
        var verts = Mesh.vertices;

        wavesDefault = (Vector4[])waves.Clone();

        Material = GetComponent<MeshRenderer>().material;
        UpdateMaterial();
    }

    public void UpdateMaterial()
    {
        if (Material != null)
        {
            for (int i = 0; i < waves.Length; i++)
            {
                waves[i].x = Mathf.Cos(0.005f * Time.timeSinceLevelLoad);
            }
            Material.SetVector("_WaveA", waves[0]);
            Material.SetVector("_WaveB", waves[1]);
            Material.SetVector("_WaveC", waves[2]);
        }
    }
}