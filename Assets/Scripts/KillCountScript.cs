using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class KillCountScript : MonoBehaviour
{
    public Text KillCountText;
    public Text endText;
    private float killCount;
    // Start is called before the first frame update
    void Start()
    {
        killCount=0f;
        setKillCountDisplay();
    }

    void Update(){
        killCount=Mathf.Ceil(killCount);
    }
    void incrementKillCount(){
        killCount+=0.5f;
        setKillCountDisplay();

        if(Mathf.Ceil(killCount)>=10){
            Debug.Log("end condition");
            StartCoroutine("callToEndScene");
        }
    }

    void setKillCountDisplay(){
        KillCountText.text = "Spiders Killed: "+Mathf.Ceil(killCount).ToString()+"/10";
    }

    IEnumerator callToEndScene(){
        Debug.Log("got to wait");
        endText.text = "LEVEL PASSED";
        yield return new WaitForSeconds(4);
        FindObjectOfType<SceneManagementScript>().endScene();
    }
}
