using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour {
    [Header("Data")]
    [SerializeField] private DataFloat speed; // 20
    [SerializeField] private DataFloat lifeTime; // 3
    [Header("Reference")]
    [SerializeField] private Data data;
    [SerializeField] public ParticleSystem pSystem;
	// Use this for initialization
	void Start () {
        speed = data.Float(speed);
        lifeTime = data.Float(lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        
        transform.Translate(0, speed.Value * dt, 0);

        lifeTime -= dt;
        if (lifeTime.Value < 0)
        {
            Destroy(gameObject);
        }
	}
}
