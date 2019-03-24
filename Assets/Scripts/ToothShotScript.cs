using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothShotScript : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    private Vector3 direction;

    //get the direction the player object is facing
    void theDirection(Vector3 direction){
        this.direction=direction;
    }
    void Start()
    {
        //theDirection(new Vector2(0,1)); testing
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        //get current position
        Vector3 position = transform.position;

        //move tooth(bullet)
        Vector3 newPosition = position + direction*speed*Time.deltaTime;
        transform.position=newPosition;

    }

}
