using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformDelta2DToData : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private DataVector2 dataNode;
    [SerializeField] private DataFloat reactionRadius;
    [SerializeField] private DataFloat counter;
    [Header("References")]
    [SerializeField] public GameObject target;
    [SerializeField] private Transform targetIdleA;
    [SerializeField] private Transform targetIdleB;
    [SerializeField] private Transform targetIdleC;
    [SerializeField] private Data data;

    IEnumerator Start()
    {
        dataNode = data.Vector2(dataNode);
        reactionRadius = data.Float(reactionRadius);

        while (true)
        {
            if (target != null)
            {
                reactionRadius.Value = 5;
                float d = Vector2.Distance(transform.position, target.transform.position);

                if (d < reactionRadius.Value)
                {
                    dataNode.Value = (target.transform.position - transform.position).normalized;
                }
                if (d > reactionRadius.Value)
                {

                    // int direction = 1 + (int)(2.99f * Mathf.PerlinNoise(counter.Value++ * 0.2f, 0.5f));
                    int direction = Random.Range(1, 4);
                    switch (direction)
                    {
                        case 1:
                            dataNode.Value = (targetIdleA.transform.position - transform.position).normalized;
                            break;
                        case 2:
                            dataNode.Value = (targetIdleB.transform.position - transform.position).normalized;
                            break;
                        case 3:
                            dataNode.Value = (targetIdleC.transform.position - transform.position).normalized;
                            break;
                    }
                }
            }
            yield return new WaitForSeconds(0.8f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //reactionRadius.Value = 5;
        //float d = Vector2.Distance(transform.position, target.transform.position);

        ////if (d < reactionRadius.Value)
        ////{
        ////    dataNode.Value = (target.transform.position - transform.position).normalized;
        ////} 
        //if (d > reactionRadius.Value){
            
        //    int direction = 1 + (int)(2.99f * Mathf.PerlinNoise(counter.Value++ * 0.2f, 0.5f));

        //    switch (direction)
        //    {
        //        case 1:
        //            dataNode.Value = (targetIdleA.transform.position - transform.position).normalized;
        //            break;
        //        case 2:
        //            dataNode.Value = (targetIdleB.transform.position - transform.position).normalized;
        //            break;
        //        case 3:
        //            dataNode.Value = (targetIdleC.transform.position - transform.position).normalized;
        //            break;
        //    }
        //}
    }
}
