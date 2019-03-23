using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed =3;
    public GameObject PlayerSkeleton;
    List<GameObject> players = new List<GameObject>(2);

    private Vector3 P1direction = new Vector3(0,-1,0);
    float lastShotP1 =0f;
    private Vector3 P2direction=new Vector3(0,-1,0);

    //Variables for shooting
    public GameObject ToothShot; //prefab
    public GameObject ToothShotOrigin; //from whence the tooth is spat

    //private int P1bullet;

    // Start is called before the first frame update
    void Start()
    {
         //add both players to the List of players
        foreach(GameObject player in GameObject.FindObjectsOfType (typeof(GameObject))){
            if(player.tag=="Player"&&!players.Contains(player))
                players.Add(player);
        }
        //P1bullet=1;
    }
    
    // Update is called once per frame
    void Update()
    {
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
            if(lastShotP1!=Time.time){
                GameObject toothBullet = (GameObject)Instantiate(ToothShot);
                toothBullet.transform.position = players[0].transform.GetChild(0).transform.position;
                toothBullet.SendMessage("theDirection", P1direction);
                lastShotP1=Time.time;
            }
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
        //for player 2 fire tooth(bullet) when f is pressed


        //P1bullet=0;
    }
}
