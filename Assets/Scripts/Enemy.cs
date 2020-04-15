using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathFX;
    [SerializeField] private Transform parent;
    [SerializeField] private int scorePerHit = 12; //maybe put it on the enemy?


    private ScoreBoard scoreBoard;
    
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject explosion = Instantiate(deathFX, transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        scoreBoard.ScoreHit(scorePerHit);
        Destroy(this.gameObject);
    }

    void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
}
