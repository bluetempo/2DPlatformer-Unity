using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Destroys finished particle
 */
public class DestroyFinishedParticle : MonoBehaviour {

    private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start () {
        thisParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!thisParticleSystem.isPlaying) Destroy(gameObject);
	}
}
