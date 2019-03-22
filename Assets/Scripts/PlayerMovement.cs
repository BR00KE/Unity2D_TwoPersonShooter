using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed =3;
    public GameObject playerSkeleton;
    List<GameObject> players = new List<GameObject>(2);

    //sprite direction
        int ydirectionP2 =1;
        //float zrotationP2 = 0;

        int ydirectionP1 =1;
        Quaternion rotationP1 = Quaternion.Euler(0,0,0);
        Quaternion rotationP2;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //add both players to the List of players
        foreach(GameObject player in GameObject.FindObjectsOfType (typeof(GameObject))){
            if(player.tag=="Player"&&!players.Contains(player))
                players.Add(player);
        }

        //Assign Arrow keys for player 1
        if(Input.GetKey(KeyCode.LeftArrow)){
            players[0].transform.Translate(Vector3.left*speed*Time.deltaTime);
            //rotationP1 = Quaternion.Euler(0,0,-90);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            players[0].transform.Translate(Vector3.right*speed*Time.deltaTime);
            //rotationP1 = Quaternion.Euler(0,0,90);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            players[0].transform.Translate(Vector3.up*speed*Time.deltaTime);
            ydirectionP1=-1;
            //rotationP1 = Quaternion.Euler(0,0,0);
        } 
        if(Input.GetKey(KeyCode.DownArrow)){
            players[0].transform.Translate(Vector3.down*speed*Time.deltaTime);
            ydirectionP1=1;
            //rotationP1 = Quaternion.Euler(0,0,0);
        }
        
        players[0].transform.localScale = new Vector2(1,ydirectionP1);
        //players[0].transform.localRotation = rotationP1;
        
        //Assign WASD keys for player 2
        if(Input.GetKey(KeyCode.A)){
            players[1].transform.Translate(Vector3.left*speed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            players[1].transform.Translate(Vector3.right*speed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.W)){
            players[1].transform.Translate(Vector3.up*speed*Time.deltaTime);
            ydirectionP2=-1;
            //zrotationP2=0;
        } 
        if(Input.GetKey(KeyCode.S)){
            players[1].transform.Translate(Vector3.down*speed*Time.deltaTime);
            ydirectionP2=1;
            //zrotationP2=0;
        }

        players[1].transform.localScale = new Vector2(1,ydirectionP2);
        //players[1].transform.localRotation = new Quaternion(0f,0f,zrotationP2);

        //stop players leaving the game area
        //playerSkeleton[0].position
    }
}
