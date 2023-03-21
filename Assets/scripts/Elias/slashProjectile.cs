using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashProjectile : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;
    public AudioClip SwordSlash;
    public AudioSource AudioSource;
    public float lifetime;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        AudioSource = GameObject.Find("Sword").GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        rb.freezeRotation = true;
        rb.gravityScale = 0;
        rb.velocity = transform.right * speed;
        StartCoroutine(waitKill());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            AudioSource.PlayOneShot(SwordSlash);
        }
    }
    IEnumerator waitKill()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
