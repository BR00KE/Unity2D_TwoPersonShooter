using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{
    bool sceneEnded =false;
    public void endScene(){
        if(!sceneEnded){
            //end scene
            sceneEnded=true;
            Debug.Log("scene ended");
            SceneManager.LoadScene(0);
        }        
        
    }
}
