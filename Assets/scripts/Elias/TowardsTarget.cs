using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TowardsTarget : MonoBehaviour
{

    // En speed for at justere dens hastighed
    public float Speed;

    //Target name er navnet på det object den skal finde
    public string TargetName;

    // Vi styrer farten med rigidbody, så vi laver en reference til den Rigidbody
    // som er (eller skal være) på dette object.
    private Rigidbody2D _rb;

    // Laver en variable til at gemme den retning som er imod Target
    private Vector2 _directionTowardsTarget;

    //Hvad er dens target?
    private GameObject Target;


    void Start()
    {
        // Finder dens rigidbody i koden ( i stedet for at trække den over)
        _rb = GetComponent<Rigidbody2D>();

        //Finder target
        Target = GameObject.Find(TargetName);
    }

    private void Update()
    {
        // Finder retningen og "normalisere"
        // (hvilket gør at den er ens uanset hvor langt target er væk
        // Dvs. man finder den retning den går i
        _directionTowardsTarget = (Target.transform.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        // Sætter hastigheden på rigidbody til retningen * Speed;
        _rb.velocity = _directionTowardsTarget * Speed;
    }
}