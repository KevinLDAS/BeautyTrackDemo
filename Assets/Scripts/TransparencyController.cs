using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TransparencyController : MonoBehaviour
{
    public Renderer renderer;

    [SerializeField] private Slider transparency;

    [SerializeField] private Text transparencyMeter;

    // Start is called before the first frame update
    void Start()
    {
        //renderer = GetComponent<Renderer>();
        renderer.material.shader = Shader.Find("Custom/TransparentDiffuse ZWrite");

        transparency = GameObject.FindObjectOfType<Slider>();
        transparencyMeter = FindObjectOfType<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float transparencyValue = transparency.value;
        for (int i = 0; i < renderer.materials.Length; i++)
        {
            renderer.materials[i].SetVector("_Color", new Vector4(1, 1, 1, transparencyValue));
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("Transparency: ");
        sb.Append(Math.Round(transparencyValue * 100, 0));
        sb.Append("%");
        transparencyMeter.text = sb.ToString();
    }
}