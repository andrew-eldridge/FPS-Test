using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : MonoBehaviour {

    public int damageAmount = 5;
    public float targetDistance;
    public float allowedDistance = 15f;

    public int enemyHealth = 15;

    AudioSource audioSource;
    Animation gunAnimation;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        gunAnimation = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            audioSource.Play();
            gunAnimation.Play();
            RaycastHit Shot;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
                targetDistance = Shot.distance;
                if (targetDistance < allowedDistance) {
                    Shot.transform.SendMessage("DeductHealth", damageAmount, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
	}

    void DeductHealth(int damage) {
        enemyHealth -= damage;
    }
}
