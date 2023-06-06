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


        // Move ball left when pressing left arrow key
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-Force*0.1f, 0, 0), ForceMode.Impulse);
        }

        // Move ball right when pressing right arrow key
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(Force*0.1f, 0, 0), ForceMode.Impulse);
        }
    }

    // void shoot()
    // {
    //     Vector3 Shoot = (target.transform.position - this.transform.position).normalized;
    //     GetComponent<Rigidbody>().AddForce(Shoot * Force + new Vector3(0, 3f, 0), ForceMode.Impulse);
    // }

    // Function that shoots the ball towards

    void shoot()
    {
        Vector3 Shoot = (target.transform.position - this.transform.position).normalized;
        GetComponent<Rigidbody>().AddForce(Shoot * Force + new Vector3(0, 3f, 0), ForceMode.Impulse);

        StartCoroutine(WaitForBallReset());
    }

    IEnumerator WaitForBallReset()
    {
        yield return new WaitForSeconds(2);
        ResetBall();
    }

    public void ResetBall()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.position = new Vector3(0, 0.45f, -3.13f);
    }
}
