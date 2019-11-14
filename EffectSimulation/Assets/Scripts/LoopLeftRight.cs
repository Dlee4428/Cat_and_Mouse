using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopLeftRight : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private DataFloat delta;
    [SerializeField] private DataFloat speed;
    [SerializeField] private DataVector3 startPos;
    [Header("References")]
    [SerializeField] private Data data;
    [SerializeField] private Transform target;

    void Start()
    {
        delta = data.Float(delta);
        speed = data.Float(speed);
        startPos = data.Vector3(startPos);
        startPos.Value = target.transform.position;
    }

    void Update()
    {
        Vector3 v = startPos.Value;
        v.x += delta.Value * Mathf.Sin(Time.time * speed.Value);
        target.transform.position = v;
    }
}
