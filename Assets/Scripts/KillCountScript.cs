using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class KillCountScript : MonoBehaviour
{
    public Text KillCountText;
    public Text endText;
    private float killCount;

    List<GameObject> players = new List<GameObject>(2);
    // Start is called before the first frame update
    void Start()
    {
        killCount=0f;
        setKillCountDisplay();

        //find player objects
        foreach(GameObject player in GameObject.FindObjectsOfType (typeof(GameObject))){
            if(player.tag=="Player"&&!players.Contains(player))
                players.Add(player);
        }
    }

    void Update(){
        killCount=Mathf.Ceil(killCount);
    }
    void incrementKillCount(){
        killCount+=0.5f;
        setKillCountDisplay();

        if(Mathf.Ceil(killCount)>=15){
            Debug.Log("end condition");
            StartCoroutine("callToEndSceneSuccess");
        }
    }

    void setKillCountDisplay(){
        KillCountText.text = "Spiders Killed: "+Mathf.Ceil(killCount).ToString()+"/15";
    }

    IEnumerator callToEndSceneSuccess(){
        //disable player objects
        players[1].SetActive(false);
        players[0].SetActive(false);

        Debug.Log("got to wait");
        endText.text = "LEVEL PASSED";
        yield return new WaitForSeconds(4);
        FindObjectOfType<SceneManagementScript>().endScene();
    }
}
