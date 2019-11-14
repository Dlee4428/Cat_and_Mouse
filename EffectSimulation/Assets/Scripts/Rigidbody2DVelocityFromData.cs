using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody2DVelocityFromData : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private DataFloat dataSpeed;
    [SerializeField] private DataFloat dataAcceleration;
    [SerializeField] private DataVector2 dataInput;
    [Header("References")]
    [SerializeField] private Data data;
    [SerializeField] private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        dataSpeed = data.Float(dataSpeed);
        dataAcceleration = data.Float(dataAcceleration);
        dataInput = data.Vector2(dataInput);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = Vector2.MoveTowards(rigidbody.velocity, (Vector2)dataInput * (float)dataSpeed, (float)dataAcceleration);
    }
}
