using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed =3;
    public GameObject playerSkeleton;
    List<GameObject> players = new List<GameObject>(2);

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
            players[0].transform.rotation = Quaternion.LookRotation(players[0].transform.forward,Vector2.right);
            players[0].transform.position += (new Vector3(-1,0,0))*Time.deltaTime*speed;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            players[0].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.left);
            players[0].transform.position += (new Vector3(1,0,0))*Time.deltaTime*speed;
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            players[0].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.down);
            players[0].transform.position += (new Vector3(0,1,0))*Time.deltaTime*speed;
        } 
        if(Input.GetKey(KeyCode.DownArrow)){
            players[0].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.up);
            players[0].transform.position += (new Vector3(0,-1,0))*Time.deltaTime*speed;
        }

        //Assign WASD keys for player 2
        if(Input.GetKey(KeyCode.A)){
            players[1].transform.rotation = Quaternion.LookRotation(players[0].transform.forward,Vector2.right);
            players[1].transform.position += (new Vector3(-1,0,0))*Time.deltaTime*speed;
        }
        if(Input.GetKey(KeyCode.D)){
            players[1].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.left);
            players[1].transform.position += (new Vector3(1,0,0))*Time.deltaTime*speed;
        }
        if(Input.GetKey(KeyCode.W)){
            players[1].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.down);
            players[1].transform.position += (new Vector3(0,1,0))*Time.deltaTime*speed;
        } 
        if(Input.GetKey(KeyCode.S)){
            players[1].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.up);
            players[1].transform.position += (new Vector3(0,-1,0))*Time.deltaTime*speed;
        }

    }
}
