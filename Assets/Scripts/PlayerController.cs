using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int treats; //number of treats (lives)

    public Animator bodyAnim;

    [SerializeField]
    private float speed;

    private float vertical, horizontal;
    private CharacterController controller;
    private GameObject dog;
    private AudioSource hurtSound;

    public List<ParticleSystem> treatParticles;

    private bool invicible = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        hurtSound = GetComponent<AudioSource>();
        bodyAnim = GetComponent<Animator>();
        dog = GameObject.FindWithTag("Dog");
        treats = 3;
    }

    private void Update()
    {
        Vector3 targetLook = new Vector3(dog.transform.position.x, transform.position.y, dog.transform.position.z);
        gameObject.transform.LookAt(targetLook);

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical);
        controller.SimpleMove(speed * direction);

        if (controller.velocity == Vector3.zero)
            bodyAnim.SetBool("isRunning", false); 
        else
            bodyAnim.SetBool("isRunning", true);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dog"))
        {
            if (!invicible)
            {
                Debug.Log("ai");
                invicible = true;
                Invoke("InvicibleTime", 3f);
                bodyAnim.SetTrigger("Hurts");
                treats--;
                hurtSound.Play();
                if (treats > 0)
                    treatParticles[treats - 1].Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rat"))
        {
            if (!invicible)
            {
                Debug.Log("ai");
                invicible = true;
                Invoke("InvicibleTime", 3f);
                bodyAnim.SetTrigger("Hurts");
                treats--;
                hurtSound.Play(); 
                if (treats > 0)
                    treatParticles[treats - 1].Play();
            }
        }
    }

    private void InvicibleTime()
    {
        invicible = false;
    }

}
