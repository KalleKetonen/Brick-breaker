using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Triggers game over

public class LooseCollider : MonoBehaviour {
    private LevelManager levelManager;
	void OnTriggerEnter2D (Collider2D trigger){
          levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Lose");

    }

    
}
