using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        if (gm != null)
        {
            gameManager = gm.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("GameManager not found! Make sure it's tagged 'GameManager'.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.currentPickups++;
                Debug.Log("Pickup collected! Total: " + gameManager.currentPickups);
                Destroy(gameObject);
            }
        }
    }
}
