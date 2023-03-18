using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WalkLeftRight : MonoBehaviour
{

    private Vector3 _startPosition;

    [Range(0, 50)]
    public float DistanceLeft = 4;
    [Range(0, 50)]
    public float DistanceRight = 4;
    public enum Direction { Left, Right }
    public Direction CurrentDirection = Direction.Left;
    public float Speed = 5;

    private Vector3 _rightTarget, _leftTarget;
    private SpriteRenderer _sr;


	private void OnDrawGizmos()
	{
        if (!Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * -DistanceLeft);
            Gizmos.DrawCube(transform.position + Vector3.right * -DistanceLeft, Vector3.one * 0.1f);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * DistanceRight);
            Gizmos.DrawCube(transform.position + Vector3.right * DistanceRight, Vector3.one * 0.1f);
        }

    }

	void Start()
    {
        _startPosition = transform.position;

        _rightTarget = transform.position + Vector3.right * DistanceRight;
        _leftTarget = transform.position + Vector3.right * -DistanceLeft;

        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (CurrentDirection == Direction.Left)
        {
            transform.position = Vector3.MoveTowards(transform.position, _leftTarget, Speed * Time.deltaTime);
            if (Mathf.Approximately(transform.position.x, _leftTarget.x))
            {
                CurrentDirection = Direction.Right;
                _sr.flipX = true;
            }
        }
        else if(CurrentDirection == Direction.Right)
        {
            transform.position = Vector3.MoveTowards(transform.position, _rightTarget, Speed * Time.deltaTime);
            if (Mathf.Approximately(transform.position.x, _rightTarget.x))
            {
                CurrentDirection = Direction.Left;
                _sr.flipX = false;
            }
        }
    }
}
