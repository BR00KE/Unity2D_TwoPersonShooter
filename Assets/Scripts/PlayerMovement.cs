using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed =3;
    public GameObject playerSkeleton;
    List<GameObject> players = new List<GameObject>(2);

    //sprite direction
        int xdirectionP2 =1;
        int ydirectionP2 =1;
        float zrotationP2 = 0;

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


        
        //Assign WASD keys for player 2
        if(Input.GetKey(KeyCode.A)){
            players[1].transform.Translate(Vector3.left*speed*Time.deltaTime);
            //xdirectionP2=1;
            zrotationP2=90;
        }
        if(Input.GetKey(KeyCode.D)){
            players[1].transform.Translate(Vector3.right*speed*Time.deltaTime);
            //xdirectionP2=-1;
            zrotationP2=-90;
        }
        if(Input.GetKey(KeyCode.W)){
            players[1].transform.Translate(Vector3.up*speed*Time.deltaTime);
            ydirectionP2=-1;
            zrotationP2=0;
        } 
        if(Input.GetKey(KeyCode.S)){
            players[1].transform.Translate(Vector3.down*speed*Time.deltaTime);
            ydirectionP2=1;
            zrotationP2=0;
        }

        players[1].transform.localScale = new Vector2(xdirectionP2,ydirectionP2);
        players[1].transform.localRotation = new Quaternion(0f,0f,zrotationP2);
    }
}
