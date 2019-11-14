using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private DataVector3 dataVec3;
    [Header("Reference")]
    [SerializeField] private Data data;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private Camera cam;

    private void Start()
    {
        dataVec3 = data.Vector3(dataVec3);
        trail = GetComponent<TrailRenderer>();
        cam = Camera.main;

        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        dataVec3.Value = cam.ScreenToWorldPoint(mousePos);
        transform.position = dataVec3.Value;
    }
}
