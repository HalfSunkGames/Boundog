using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverTextureScript : MonoBehaviour
{
    [SerializeField]
    private float speedX = -0.5f;
    [SerializeField]
    private float speedY = 0f;

    private float curX;
    private float curY;
    private Material mat;
    private Vector2 curPosition;

    // Use this for initialization
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        curX = mat.mainTextureOffset.x;
        curY = mat.mainTextureOffset.y;
        curPosition = new Vector2(curX, curY);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        curX += Time.deltaTime * speedX;
        curY += Time.deltaTime * speedY;
        curPosition.Set(curX, curY);

        mat.SetTextureOffset("_MainTex", curPosition);
    }
}
