using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed =3;
    //public GameObject PlayerSkeleton;
    List<GameObject> players = new List<GameObject>(2);

    private Vector3 P1direction = new Vector3(0,-1,0);
    private Vector3 P2direction = new Vector3(0,-1,0);
    //Variables for shooting
    public GameObject ToothShot; //prefab
    //public GameObject ToothShotOrigin; //from whence the tooth is spat

    //private int P1bullet;

    // Start is called before the first frame update
    void Start()
    {
         //add both players to the List of players
        foreach(GameObject player in GameObject.FindObjectsOfType (typeof(GameObject))){
            if(player.tag=="Player"&&!players.Contains(player))
                players.Add(player);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("top of update");
        //Assign Arrow keys for player 1
        if(Input.GetKey(KeyCode.LeftArrow)){
            players[0].transform.rotation = Quaternion.LookRotation(players[0].transform.forward,Vector2.right);
            P1direction=new Vector3(-1,0,0);
            players[0].transform.position+=P1direction*speed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            players[0].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.left);
            P1direction=new Vector3(1,0,0);
            players[0].transform.position+=P1direction*speed*Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            players[0].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.down);
            P1direction=new Vector3(0,1,0);
            players[0].transform.position+=P1direction*speed*Time.deltaTime;
        } 
        if(Input.GetKey(KeyCode.DownArrow)){
            players[0].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.up);
            P1direction=new Vector3(0,-1,0);
            players[0].transform.position+=P1direction*speed*Time.deltaTime;
        }
        //for player 1 fire tooth(bullet) when enter pressed
        if(Input.GetKeyDown(KeyCode.M)){
            
            //instantiate tooth projectile
            GameObject toothBullet = (GameObject)Instantiate(ToothShot);
            toothBullet.transform.position = players[0].transform.GetChild(0).position;
            toothBullet.transform.rotation = players[0].transform.GetChild(0).rotation;
            toothBullet.SendMessage("theDirection", P1direction);
        }

        //Assign WASD keys for player 2
        if(Input.GetKey(KeyCode.A)){
            players[1].transform.rotation = Quaternion.LookRotation(players[0].transform.forward,Vector2.right);
            P2direction = new Vector3(-1,0,0);
            players[1].transform.position += P2direction*Time.deltaTime*speed;
        }
        if(Input.GetKey(KeyCode.D)){
            players[1].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.left);
            P2direction = new Vector3(1,0,0);
            players[1].transform.position += P2direction*Time.deltaTime*speed;
        }
        if(Input.GetKey(KeyCode.W)){
            players[1].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.down);
            P2direction = new Vector3(0,1,0);
            players[1].transform.position += P2direction*Time.deltaTime*speed;
        } 
        if(Input.GetKey(KeyCode.S)){
            players[1].transform.rotation=Quaternion.LookRotation(players[0].transform.forward,Vector2.up);
            P2direction = new Vector3(0,-1,0);
            players[1].transform.position += P2direction*Time.deltaTime*speed;
        }
        //for player 2 fire tooth(bullet) when f is pressed
        if(Input.GetKeyDown(KeyCode.F)){
            //instantiate tooth projectile
            //Debug.Log("player 2 spat tooth begin");
            GameObject toothBullet = (GameObject)Instantiate(ToothShot);
            toothBullet.SendMessage("theDirection", P2direction); 
            toothBullet.transform.position = players[1].transform.GetChild(0).position;
            toothBullet.transform.rotation = players[1].transform.GetChild(0).rotation;
            //Debug.Log("player 2 spat tooth end");
        }

    }
}
