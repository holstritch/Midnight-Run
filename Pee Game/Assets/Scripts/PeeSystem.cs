using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeSystem : MonoBehaviour
{
    public ParticleSystem peeStream;
    public Transform toiletTf;
    
    public bool peeOnce = true; 

    [Range(0f, 4f)]
    public float triggerRadius = 2f; 

    private void Update()
    {
        float dist = getDistanceFromToilet();

        if (dist < triggerRadius && peeOnce)
        {
            peeStream.Play();
            peeOnce = false;
        }
    }
    private void OnDrawGizmos()
    {
        float dist = getDistanceFromToilet();
        bool isInside = dist < triggerRadius;

        Gizmos.color = isInside ? Color.green : Color.red;

        Gizmos.DrawWireSphere(toiletTf.position, 2f);
    }

    private float getDistanceFromToilet()
    {
        Vector3 playerPos = transform.position;
        Vector3 toiletOrigin = toiletTf.position;

        float dist = Vector3.Distance(playerPos, toiletOrigin);

        return dist;
    }   
}
