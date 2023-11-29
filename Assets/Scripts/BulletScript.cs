using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;

    private Vector3 Direction;
    private Rigidbody2D Rigidbody2D;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GruntScript grunt = collision.GetComponent<GruntScript>();
        JohnMovement john = collision.GetComponent<JohnMovement>();
        if (john != null)
        {
            john.Hit();
        }
        if (grunt != null)
        {
            grunt.Hit();
        }
        DestroyBullet();
    }
}
