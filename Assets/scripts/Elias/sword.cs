using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public Animator anim;

    public AudioClip SwordHit, SwordSlash;
    public AudioSource AudioSource;

    public GameObject airSlash;
    public Transform pivot;
    public Transform spawnPoint;
    public float slashTimer;
    public bool slashing;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !slashing)
        {
            anim.SetTrigger("slash");
            AudioSource.PlayOneShot(SwordSlash);
            StartCoroutine(attack(slashTimer));
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && !slashing)
        {
            anim.SetTrigger("slash");
            GameObject tempAirSlash = Instantiate(airSlash, spawnPoint.position, Quaternion.identity);
            tempAirSlash.transform.right = pivot.transform.right;
            AudioSource.PlayOneShot(SwordSlash);
            StartCoroutine(attack(slashTimer));
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

    IEnumerator attack(float timer)
    {
        slashing = true;
        yield return new WaitForSeconds(timer);
        slashing = false;
    }
}
