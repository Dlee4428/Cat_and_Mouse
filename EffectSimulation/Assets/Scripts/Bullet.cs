using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private DataFloat bulletTimer; // 0
    [SerializeField] private DataFloat bulletCoolDown; // 1
    [SerializeField] private DataFloat timer;
    [SerializeField] private int score;
    [Header("Reference")]
    [SerializeField] public Data data;
    [SerializeField] public GameObject bullet;
    [SerializeField] public Transform gun;
    [SerializeField] public ParticleSystem gParticle;
    [SerializeField] public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        bulletTimer = data.Float(bulletTimer);
        bulletCoolDown = data.Float(bulletCoolDown);
        timer = data.Float(timer);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        bulletTimer.Value -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletTimer.Value < 0)
            {
                Debug.Log("Fire");
                bulletTimer.Value = bulletCoolDown.Value;
                Instantiate(bullet, gun.position, gun.transform.rotation);
                gParticle.transform.position = gun.position;
                gParticle.Play();
            }
        }
        if(timer.Value > 2f)
        {
            score += 100;
            countText.text = score.ToString();
            timer.Value = 0;
        }
    }
}
