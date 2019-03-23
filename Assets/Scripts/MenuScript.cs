using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void playLevelOne()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);   
    }

    public void playeLevelTwo()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
    }
    public void playLevelThree()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); 
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
