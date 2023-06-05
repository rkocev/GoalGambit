using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    public float Force;
    public Transform target;
    public Slider forceUI;
    Goalkeeper goal;
    public GameObject Goalkeeper;
    Vector3 StartPos;
    Vector3 GoalPos;

    void Start()
    {
        StartPos = transform.position;
        GoalPos = Goalkeeper.transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Force++;                                //Hold space key to add force to the ball.                                
            slider();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(Wait());
        }
    }

    void shoot()
    {
        Vector3 Shoot = (target.position - this.transform.position).normalized;
        GetComponent<Rigidbody> ().angluarDrag = 1;
        GetComponent<Rigidbody> ().AddForce(Shoot * Force, ForceMode.Impulse);

    }

    public void slider()
    {
        forceUI.value = 0;
    }

    public void ResetGauge()
    {
        Force = 0;
        forceUI.value = 0;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);      //Wait for a while before resetting slider value and force.
        shoot();
        yield return new WaitForSeconds(0.05f);
        FindObjectOfType<Goalkeeper>().GoalMove();
        yield return new WaitForSeconds(1.5f);
        ResetGauge();                               //Reset Force and slider value after shoot.

        GetComponent<Rigidbody>().angluarDrag = 40;
        yield return new WaitForSeconds(3f);

        transform.position = StartPos;              //Reset ball position.
        Goalkeeper.transform.position = GoalPos;    //Reset goalkeeper position.

        FindObjectOfType<Goalkeeper>().Reset();
        FindObjectOfType<Goalkeeper>().Move = 0;    //Reset index.
    }
}
