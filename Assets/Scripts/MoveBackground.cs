using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBackground : MonoBehaviour
{
    RawImage background;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        Rect rect = background.uvRect;

        rect.x += speed * Time.deltaTime;
        rect.y += speed * Time.deltaTime;

        background.uvRect = rect;
    }
}
