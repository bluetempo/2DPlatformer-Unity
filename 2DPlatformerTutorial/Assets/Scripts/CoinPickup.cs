using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int pointsToAdd;
    public LevelManager levelManager;

    void Start()
    {
        // finds any object in the scene that has Level Manager
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<PlayerController>() == null) return;

        levelManager.PlayCoinAnimation();
        ScoreManager.AddPoints(pointsToAdd);
        Destroy(gameObject);
    }
}
