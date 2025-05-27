using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    // Pickup and Level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;
    public Text pickupText;

    //Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 15.0f;

    public Transform door;
    public float doorProximity = 10.0f;
    private Animation[] doorAnimations;
    private Dictionary<Animation, bool> hasPlayedMap = new Dictionary<Animation, bool>();

    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }

    private void LevelCompleteCheck()
    {
        if (currentPickups >= maxPickups)
            levelComplete = true;
        else
            levelComplete = false;
    }

    private void UpdateGUI()
    {
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }

    private void PlayAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i] != null)
            {
                if (Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity)
                {
                    if (!audioSources[i].isPlaying)
                    {
                        audioSources[i].Play();
                    }
                }
            }
        }
    }
    
    private void AutomaticDoor()
    {
        foreach (Animation anim in doorAnimations)
        {
            float distance = Vector3.Distance(player.transform.position, anim.transform.position);

            if (distance <= doorProximity && !hasPlayedMap[anim])
            {
                anim.Play();
                hasPlayedMap[anim] = true;
            }
            else if (distance > doorProximity && hasPlayedMap[anim])
                hasPlayedMap[anim] = false;
        }
    }
}
