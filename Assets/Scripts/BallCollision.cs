using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    ParticleSystem particleSystem;
    int ballIndex;

    public int  totalLife = 3;


    public AudioClip Explosion;
    private AudioSource audioSource;


    private void Start()
    {
        particleSystem = transform.GetChild(0).GetComponent<ParticleSystem>();
        ballIndex = transform.position.x > 0 ? 0 : 1;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Explosion;
    }

    private void Update()
    {
        if(totalLife == 0)
            GameManager.Instance.isGameOver = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacles"))
        {
            

            particleSystem.Play();
            Splatters.instance.AddSplatter(collision.transform, collision.contacts[0].point, ballIndex);     

            audioSource.Play();

            PlayerMovements.Instance.Restart();

            totalLife--;

            
        }
    }
}
