using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeSystem : MonoBehaviour
{
    public ParticleSystem peeStream;
    public Transform toiletTf;

    public bool once = true; //only pee once

    [Range(0f, 4f)]
    public float radius = 2f; //size of trigger zone

    private void Update()
    {
        Vector3 playerPos = transform.position;          //get rid of repeated code
        Vector3 toiletOrigin = toiletTf.position;

        float dist = Vector3.Distance(playerPos, toiletOrigin);

        if (dist < radius && once)
        {
            peeStream.Play();
            once = false;
        }
    }
    private void OnDrawGizmos() //visual toilet zone
    {
        Vector3 playerPos = transform.position;
        Vector3 toiletOrigin = toiletTf.position;

        float dist = Vector3.Distance(playerPos, toiletOrigin);
        bool isInside = dist < radius;

        Gizmos.color = isInside ? Color.green : Color.red;

        Gizmos.DrawWireSphere(toiletOrigin, 2f);

    }
}
