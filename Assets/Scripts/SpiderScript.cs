using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    public float speed;
    public float range;

    private readonly float directionChangeTime = 3f;
    private float latestDirectionChangeTime;
    Vector2 movementDirection;
    List<GameObject> players = new List<GameObject>(2);

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject player in GameObject.FindObjectsOfType (typeof(GameObject))){
            if(player.tag=="Player"&&!players.Contains(player))
                players.Add(player);
        }
        latestDirectionChangeTime =Time.time;
        movementDirection = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        fleeClosestPlayer();
        
    }

    public void fleeClosestPlayer(){

        float distanceToP1 = Vector3.Distance(players[0].transform.position,transform.position);
        float distanceToP2 = Vector3.Distance(players[1].transform.position,transform.position);

        //Flee closest player
        if(distanceToP1<distanceToP2 && distanceToP1<range){
            //multiplication by negative one will cause spider to flee instead of approach
            transform.position = Vector2.MoveTowards(transform.position, players[0].transform.position, -1 * speed * Time.deltaTime);
        }
        else if(distanceToP2<=distanceToP1 && distanceToP2<range){
            transform.position = Vector2.MoveTowards(transform.position, players[1].transform.position, -1 * speed * Time.deltaTime);
        }
        //Move Randomly
        else{
            
            if(Time.time - latestDirectionChangeTime>directionChangeTime){
                movementDirection = new Vector2(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f)).normalized;
                
                latestDirectionChangeTime=Time.time;
            }
            transform.position = new Vector2(transform.position.x+(movementDirection.x*speed*Time.deltaTime),transform.position.y+(movementDirection.y*speed*Time.deltaTime));
        }

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Bullet")){
            //Debug.Log("got to on trigger enter spider");
            Destroy(other.gameObject); //destroy bullet
            //send message to increment KillCount
            this.SendMessageUpwards("incrementKillCount");
            //gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

}
