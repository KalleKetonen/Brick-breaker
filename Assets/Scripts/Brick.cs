using UnityEngine;
using System.Collections;



public class Brick : MonoBehaviour {

    

    public Sprite[] hitSpirtes;
    public static int breakableCount = 0;
    
    private int timesHit;
    private LevelManager levelmanager;
    private bool isBreakable;
    private bool isWin;


    // Initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        isWin = (this.tag == "Win");
        if (isBreakable)
      {
            breakableCount++;
        }


        timesHit = 0;
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
               	
	}

    

    void OnCollisionEnter2D (Collision2D col){
        
        if (isBreakable)
        {
            HandleHits();
        }
        if (isWin)
        {
            WinLevel();
        }
    }

    void HandleHits ()
    {
        timesHit++;
        int maxHits = hitSpirtes.Length + 1;
        if (timesHit >= maxHits){
            breakableCount--;
            levelmanager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }

    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSpirtes[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSpirtes[spriteIndex];
        }
    }


    void WinLevel()
    {
         levelmanager.LoadNextLevel();
       
    }

    


}
