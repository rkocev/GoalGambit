using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Force;
    public Transform target;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }

    void shoot()
    {
        Vector3 Shoot = (target.transform.position - this.transform.position).normalized;
        GetComponent<Rigidbody>().AddForce(Shoot * Force + new Vector3(0, 3f, 0), ForceMode.Impulse);
    }
}
