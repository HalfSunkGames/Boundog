using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraPosition;

    private GameObject dog;
    private GameObject player;

    private Vector3 camPos;
    private Vector3 playerPos, dogPos;

    [SerializeField]
    private float camHeightIncrement;

    private float minCamHeight = 7;
    
    void Start()
    {
        dog = GameObject.FindWithTag("Dog");
        player = GameObject.FindWithTag("Player");
    }

    void LateUpdate()
    {
        playerPos = player.transform.position;
        dogPos = dog.transform.position;

        camPos = LerpByDistance(playerPos, dogPos, cameraPosition);

        // Sets the calculated position:
        gameObject.transform.position = camPos;
    }

    private Vector3 LerpByDistance(Vector3 A, Vector3 B, float percent)
    {
        // Finds a point P in a line drawn by two point A (player) and B (dog).
        // P represents the mediatrix of these points
        // x is the distance percentage between 0 and (A-B).Length()

        Vector3 P = (A + percent * (B - A));
        P.y += Vector3.Distance(B, A)* camHeightIncrement + minCamHeight;
        return P;
    }
}
