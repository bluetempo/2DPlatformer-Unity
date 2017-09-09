using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Determines where player respawns
 * 
 */

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController player;

    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;

    public int pointPenaltyOnDeath;

    public GameObject coinParticle;
    public float gravity;

    // Use this for initialization
    void Start() {
        player = FindObjectOfType<PlayerController>();
        gravity = player.GetComponent<Rigidbody2D>().gravityScale;
    }

    // Update is called once per frame
    void Update() {

    }

    public void RespawnPlayer() {
        StartCoroutine("RespawnPlayerCo");
    }

    public void PlayCoinAnimation() {
        //StartCoroutine("PlayCoinAnimationCo");
        Instantiate(coinParticle, player.transform.position, player.transform.rotation);
    }

    /*
     * Co-routine: happens outside the normal sequence of events
     */
    public IEnumerator RespawnPlayerCo() {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        // prevents player interaction and rendering
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.GetComponent<Renderer>().enabled = false;
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        // prevents camera from sliding after dying
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log("Player respawn");
        // how long to pause
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = currentCheckpoint.transform.position;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
        player.enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = gravity;
        player.GetComponent<Renderer>().enabled = true;
    }
}
