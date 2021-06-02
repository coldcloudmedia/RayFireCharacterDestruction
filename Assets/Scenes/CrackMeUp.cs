using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;
using System;

public class CrackMeUp : MonoBehaviour
{
    private SkinnedMeshRenderer[] skinnedMeshRenderers;
    private MeshRenderer[] meshRenderers;
    private Mesh[] meshes;

    public int demolitionAmount;

    void Start()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();

        meshes = new Mesh[skinnedMeshRenderers.Length];
        for(int i = 0;i < meshes.Length; i++)
        {
            meshes[i] = new Mesh();
            skinnedMeshRenderers[i].BakeMesh(meshes[i]);
            skinnedMeshRenderers[i].gameObject.AddComponent(typeof(MeshFilter));
        }

        initRayFire();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            HandleMeshRenderers();
            HandleSkinnedMeshRenderers();
        }
    }

    private void HandleSkinnedMeshRenderers()
    {        
        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            SkinnedMeshRenderer skinnedMeshRenderer = skinnedMeshRenderers[i];
        
            GameObject skinnedMeshGO = skinnedMeshRenderer.gameObject;
            skinnedMeshGO.GetComponent<MeshFilter>().mesh = meshes[i];

            skinnedMeshRenderer.enabled = false;

            skinnedMeshGO.GetComponent<RayfireRigid>().Demolish();
        }
    }

    private void initRayFire()
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            GameObject meshGO = meshRenderer.gameObject;
            meshGO.AddComponent(typeof(RayfireRigid));
            meshGO.GetComponent<RayfireRigid>().meshDemolition.amount = demolitionAmount;
            meshGO.GetComponent<RayfireRigid>().InitMeshFragments();
            meshGO.GetComponent<RayfireRigid>().physics.materialType = MaterialType.Glass;
        }

        foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
        {
            if (skinnedMeshRenderer != null)
            {
                GameObject skinnedMeshGO = skinnedMeshRenderer.gameObject;

                skinnedMeshGO.AddComponent(typeof(RayfireRigid));
                skinnedMeshGO.GetComponent<RayfireRigid>().meshDemolition.amount = demolitionAmount;
                skinnedMeshGO.GetComponent<RayfireRigid>().Initialize();
                skinnedMeshGO.GetComponent<RayfireRigid>().InitMeshFragments();
                skinnedMeshGO.GetComponent<RayfireRigid>().physics.materialType = MaterialType.Glass;
            }
        }

    }

    private void HandleMeshRenderers()
    {
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            GameObject meshGO = meshRenderer.gameObject;
            meshGO.GetComponent<RayfireRigid>().Demolish();

        }
    }
}

