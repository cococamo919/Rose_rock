using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Header("Stats")]
    public int damage = 5;

    [Header("LifeTime")]
    public float lifeTime = 5f;
    public float halfLife = 5f;

    [Header("Velocity")]
    public float vel = 10f;

    private void OnEnable()
    {
        halfLife = lifeTime;
    }

    private void FixedUpdate()
    {
        halfLife -= Time.deltaTime;
        if (halfLife <= 0)
        { gameObject.SetActive(false); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.transform.tag != "Player")
        {
            if(collision.tag == "Enemy")
            { collision.GetComponent<Enemy>().Damage(damage); }
            gameObject.SetActive(false);
        }
    }


}
