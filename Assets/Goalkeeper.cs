using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    public int[] Pos; 
    public int Move;
    public int index;
    Animator goalKeeper;



    // Start is called before the first frame update
    void Start()
    {
        goalKeeper = GetComponent<Animator>();
    }

    void fixedUpdate()
    {
        if(Move == 0){
            Reset();
        }

        if(Move == 1){
            SaveR();
        }

        if(Move == 2){
            SaveL();
        }
    }

    public void GoalMove()
    {
        index = Random.Range(0, Pos.Length);
        Move = Pos[index];
    }

    public void SaveR()
    {
        goalKeeper.SetFloat("Save", 0.5f);
    }

    public void SaveL()
    {
        goalKeeper.SetFloat("Save", 1f);
    }

    public void Reset()
    {
        goalKeeper.SetFloat("Save", 0f);
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
