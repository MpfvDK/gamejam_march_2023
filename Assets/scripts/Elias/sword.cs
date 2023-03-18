using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public Animator anim;

    public AudioClip SwordHit, SwordSlash;
    public AudioSource AudioSource;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("slash");
            AudioSource.PlayOneShot(SwordSlash);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            Destroy(collision.gameObject);
            AudioSource.PlayOneShot(SwordHit);
        }
    }
}
