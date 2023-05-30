using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureParallax : MonoBehaviour
{
    Material mat;
    float distance;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Time.deltaTime*speed;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
