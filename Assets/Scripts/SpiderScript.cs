using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    public float speed;
    List<GameObject> players = new List<GameObject>(2);
    // Start is called before the first frame update


    void Start()
    {
        foreach(GameObject player in GameObject.FindObjectsOfType (typeof(GameObject))){
            if(player.tag=="Player"&&!players.Contains(player))
                players.Add(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject closestPlayer = findClosestPlayer();
        
        //multiplication by negative one will cause spider to flee instead of approach
        transform.position = Vector2.MoveTowards(transform.position, closestPlayer.transform.position, -1 * speed * Time.deltaTime);
    }

    public GameObject findClosestPlayer(){

        float distanceToP1 = Vector3.Distance(players[0].transform.position,transform.position);
        float distanceToP2 = Vector3.Distance(players[1].transform.position,transform.position);

        if(distanceToP1<distanceToP2){
            return players[0];
        }
        else{
            return players[1];
        }

    }
}
