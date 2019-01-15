using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	// Initialization
	 public void LoadLevel(string name){
        Debug.Log("Level load requested for " + name);
          SceneManager.LoadScene(name);
    }
    
    public void QuitRequest(){
        Debug.Log("I want to quit");
        Application.Quit();
    }

    public void LoadNextLevel(){
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed(){
       if (Brick.breakableCount <= 0) {
           LoadNextLevel();
        }
    }
}
