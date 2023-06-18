using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class DogController : MonoBehaviour
{
    public GameObject ratty;
    public ParticleSystem smoke;
    public ParticleSystem runningSmoke;
    public UnityEvent killedRat;
    public AudioSource killSound;
    public AudioSource ratdieSound;

    private GameObject player;
    private Rigidbody dogBody;
    private Animator dogAnim;

    public Transform rayCastZone;
    private RaycastHit hit;
    private GameObject objectHit;

    //Physics
    [SerializeField]
    private float attractionForce = 15f;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        dogBody = GetComponent<Rigidbody>();
        dogAnim = GetComponent<Animator>();
        ratty.SetActive(false);

        smoke.Stop();
        runningSmoke.Stop();
    }


    private void Update()
    {
        Ray ray = new Ray(rayCastZone.position, -Vector3.up);

        if (Physics.Raycast(ray, out hit))
        {
            // Debud para ver el rayo
            Vector3 dirHit = hit.point;
            dirHit = dirHit - rayCastZone.position;
            Debug.DrawRay(rayCastZone.position, dirHit, Color.blue);

            objectHit = hit.transform.gameObject;

            if (objectHit.CompareTag("SlowGround"))
            {
                attractionForce = 7f;
            }
            else
            {
                attractionForce = 10f;
            }

        }

    }
    private void FixedUpdate()
    {
        Vector3 playerPosHit = player.transform.position;
        playerPosHit.y += 1;
        Vector3 rayDirection = (playerPosHit - rayCastZone.position).normalized;
        Ray ray = new Ray(rayCastZone.position, rayDirection);
        

        if (Physics.Raycast(ray, out hit))
        {
            // Debug para ver el rayo
            Vector3 dirHit = hit.point;
            dirHit = dirHit - rayCastZone.position;
            Debug.DrawRay(rayCastZone.position, dirHit, Color.red);

            objectHit = hit.transform.gameObject;

            if (objectHit.CompareTag("Player"))
                RunAtPlayer();
            else
                StopRunning();
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rat") && ratty.activeSelf == false)
        {
            // Dog attacks
            dogAnim.SetTrigger("Attack");
            killSound.Play();
            Invoke("RatSound", 0.5f);
            dogBody.velocity = Vector3.zero;
            ratty.SetActive(true);

            Invoke("EnableDisableRatty", 1.0f);

            // Rat dies
            killedRat.Invoke();
            Destroy(other.gameObject);
        }
    }
    private void RatSound()
    {
        ratdieSound.Play();
    }


    private void EnableDisableRatty()
    {
        ratty.SetActive(!ratty.activeSelf);
        smoke.Play();
    }

    private void RunAtPlayer()
    {
        dogBody.isKinematic = false;
        gameObject.transform.LookAt(player.transform.position);
        dogBody.AddForce(dogBody.transform.forward * attractionForce);

        if (!runningSmoke.isPlaying)
        {
            dogAnim.SetBool("isRunning", true);
            runningSmoke.Play();
        }
        //Posibilidad de aumentar la velocidad de la animación cuando el perro vaya + rapido
        //dogAnim.speed = (dogBody.velocity.x  + dogBody.velocity.y )/ 2;
    }

    private void StopRunning()
    {
        dogBody.isKinematic = true;
        dogBody.velocity = Vector3.zero;
        dogAnim.SetBool("isRunning", false);
        runningSmoke.Stop();
    }
}
