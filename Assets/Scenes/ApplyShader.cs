using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyShader : MonoBehaviour
{

    public Material newMaterialRef;

    public Shader shader;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Transform transform in transform)
        {
            Renderer renderer = transform.gameObject.GetComponent<Renderer>();
            if(renderer != null)
            {
                renderer.material = newMaterialRef;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            SkinnedMeshRenderer[] skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

            Debug.Log("Got " + skinnedMeshRenderers.Length + " skinned mesh renderers ");

            Material[] rockMaterials = new Material[] { newMaterialRef };

            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                if (meshRenderer != null)
                {
                    foreach (Material material in meshRenderer.materials)
                    {
                        material.shader = shader;
                    }

                }
            }
            foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers)
            {
                if (skinnedMeshRenderer != null)
                {
                    Debug.Log(skinnedMeshRenderer.gameObject.name + " skinnedMeshRenderer.materials.Length " + skinnedMeshRenderer.materials.Length, skinnedMeshRenderer.gameObject);
                    Debug.Log(skinnedMeshRenderer.gameObject.name + " skinnedMeshRenderer.sharedMaterials.Length " + skinnedMeshRenderer.sharedMaterials.Length, skinnedMeshRenderer.gameObject);
                    Debug.Log("----------------------------------------------------------------------------------------");

                    foreach (Material material in skinnedMeshRenderer.materials)
                    {
                        material.shader = shader;
                    }

                }
            }

        }

    }
}
