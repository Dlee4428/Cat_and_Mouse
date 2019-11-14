using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformWallPosition : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 pos = target.transform.position;

        if (other.gameObject.CompareTag("TopWall")) pos.y = -8.36f;
        if (other.gameObject.CompareTag("BottomWall")) pos.y = 8.41f;
        if (other.gameObject.CompareTag("RightWall")) pos.x = -16.11f;
        if (other.gameObject.CompareTag("LeftWall")) pos.x = 15.9f;

        target.transform.position = pos;

        Debug.Log(pos);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    }
}
