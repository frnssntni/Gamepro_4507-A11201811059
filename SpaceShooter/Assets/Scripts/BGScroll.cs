using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scroll_speed = 0.1f;

    private MeshRenderer mesh_Renderer;

    private float x_scroll;

    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll (){
        x_scroll = Time.time * scroll_speed;
        Vector2 offset = new Vector2(x_scroll, 0f);
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

    }
}
