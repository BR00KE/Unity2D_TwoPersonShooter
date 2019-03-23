using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCountScript : MonoBehaviour
{
    private float killCount;
    // Start is called before the first frame update
    void Start()
    {
        killCount=0;
    }

    void incrementKillCount(){
        killCount+=0.5f;
        Debug.Log("Kill count incremented");
        Debug.Log(killCount);
    }
}
