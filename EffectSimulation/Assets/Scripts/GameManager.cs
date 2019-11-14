using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] public GameObject[] spawningPoints;
    [SerializeField] public GameObject cat;
    [SerializeField] public GameObject player;

    // Use this for initialization
    IEnumerator Start()
    {
        while (true)
        {
            // To do : Select one of the spawning points(spawningPoints) randomly
            // and then instantiate an alien object
            // Don't forget to set the alien's target to player
            int spawn = Random.Range(0, spawningPoints.Length);

            Instantiate(cat, spawningPoints[spawn].transform.position, Quaternion.identity);

            if (player != null)
            {
                cat.GetComponent<TransformDelta2DToData>().target = player;
            }

            yield return new WaitForSeconds(2f);
        }
    }
}
