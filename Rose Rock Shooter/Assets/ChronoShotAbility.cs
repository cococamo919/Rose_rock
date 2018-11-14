using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChronoShotAbility : MonoBehaviour
{
    [Header("Debug")]
    public float effectTime = 5;
    public float timeScale = 0.50f;
    public float newPlayerMoveSpeed;
    public float prevPlayerMoveSpeed;
    public float projectileVel;


    private void OnEnable()
    {
        print("Started ChronoShift");
        StartCoroutine(ChronoShift());
    }

    IEnumerator ChronoShift()
    {
        PlayerController playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        GetComponent<Rigidbody2D>().velocity = transform.right * projectileVel;

        Time.timeScale = timeScale;
        prevPlayerMoveSpeed = playerController.speed;
        playerController.speed = newPlayerMoveSpeed;

        yield return new WaitForSecondsRealtime(effectTime);

        Time.timeScale = 1f;
        playerController.speed = prevPlayerMoveSpeed;

        Destroy(gameObject);
        yield return null;
    }

}
