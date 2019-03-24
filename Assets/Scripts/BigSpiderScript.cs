using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigSpiderScript : MonoBehaviour
{
    public Text endText;
    public GameObject player1;
    public GameObject player2;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Each big spider chases corresponding player
        if(gameObject.tag=="BigSpider1"){
            transform.position = Vector2.MoveTowards(transform.position, player1.transform.position, 1 * speed * Time.deltaTime);
        }
        else if(gameObject.tag=="BigSpider2"){
            transform.position = Vector2.MoveTowards(transform.position, player2.transform.position, 1 * speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D other){
        //can't kill the big spiders, they can kill you
        if(other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject); //destroy bullet
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        //Debug.Log("got to onCollision Enter");
        if(col.gameObject.CompareTag("Player")){
            col.gameObject.SetActive(false);
            //Debug.Log("player disabled");
        }
        //if both players are disabled end level
        if(!player1.activeSelf&&!player2.activeSelf){
            StartCoroutine("callToEndSceneFailed");
        }
    }

    IEnumerator callToEndSceneFailed(){
        endText.text = "LEVEL FAILED";
        yield return new WaitForSeconds(4);
        FindObjectOfType<SceneManagementScript>().endScene();
    }
}
