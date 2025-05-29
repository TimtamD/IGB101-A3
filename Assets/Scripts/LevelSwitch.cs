using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSwitch : MonoBehaviour
{
    GameEthanManager gameManager;
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameEthanManager>();
    }

    private void OnTriggerEnter(Collider otherObject){

        if (otherObject.transform.tag == "Player"){
            
            if(gameManager.levelComplete){
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
    
}
