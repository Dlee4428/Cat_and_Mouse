using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCollision : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField]public MainMenuManager manager;
    [SerializeField]public ParticleSystem pSystem;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(manager.GetComponent<MainMenuManager>().mainMenu);
        }

        if (other.tag == "Bullet")
        {
            Debug.Log("Particle");
            pSystem.gameObject.SetActive(true);
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<TrailRenderer>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            Destroy(gameObject, pSystem.main.duration);
        }
    }
}
