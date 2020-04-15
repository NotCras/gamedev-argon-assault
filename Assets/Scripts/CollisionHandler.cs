using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("Units in seconds")][SerializeField] private float loadLevelDelay = 1f;
    [Tooltip("Effects prefab on player")][SerializeField] private GameObject deathFX;
    
    private void OnTriggerEnter(Collider other)
    {
        print("Player triggered something.");
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadLevel", loadLevelDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
