using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

    public float zoom;
    private Transform player;


	void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
	}
	

	void Update ()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, zoom);

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
            print("Looking for new player... (SmoothFollow class)");
        }
	}
}
