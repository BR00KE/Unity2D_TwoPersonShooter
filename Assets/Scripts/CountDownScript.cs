using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    //public float timeLimit;
    public Text TimeRemainingText;
    public Text endText;

    public float levelTimer;

    private bool levelended;

    List<GameObject> players = new List<GameObject>(2);
    void Start()
    {
        levelended=false;

        foreach(GameObject player in GameObject.FindObjectsOfType (typeof(GameObject))){
            if(player.tag=="Player"&&!players.Contains(player))
                players.Add(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //currentTime=TimeRemainingText.time;
        levelTimer-=Time.deltaTime;

        if(levelTimer>0){
            if(!levelended){
                float minutes = (levelTimer / 60);
                float seconds = (levelTimer % 60);
                TimeRemainingText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
                //TimeRemainingText.text = "Time Remaining: "+(levelTimer);
            }
        }
        else{
            //time is up end scene
            levelended=true;
            StartCoroutine("callToEndSceneFailed");
        }
    }
    IEnumerator callToEndSceneFailed(){
        //disable players
        players[1].SetActive(false);
        players[0].SetActive(false);

        Debug.Log("got to wait");
        endText.text = "LEVEL FAILED";
        yield return new WaitForSeconds(4);
        FindObjectOfType<SceneManagementScript>().endScene();
    }
}
