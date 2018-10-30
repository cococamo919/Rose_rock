using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehavior : MonoBehaviour
{
    public float MovementFactor = 1.0f;

    protected GameObject m_Camera;


    void Start()
    {
        m_Camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        Vector3 Position;
        Vector3 Camera;
        SpriteRenderer sr;


        sr = GetComponent<SpriteRenderer>();

/*        if (Input.GetKey("w"))
        {
            gameObject.transform.Translate(Vector3.up * MovementFactor * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            gameObject.transform.Translate(Vector3.down * MovementFactor * Time.deltaTime);
        }*/

        if (Input.GetKey("a"))
        {
            gameObject.transform.Translate(Vector3.left * MovementFactor * Time.deltaTime);
            sr.flipX = true;
        }

        if (Input.GetKey("d"))
        {
            gameObject.transform.Translate(Vector3.right * MovementFactor * Time.deltaTime);
            sr.flipX = false;
        }

        Position = transform.position;
        Position.x = Mathf.Clamp(Position.x, -9.3f, 19.4f);
        Position.y = Mathf.Clamp(Position.y, -1.1f, 3f);
        transform.position = Position;

        Camera = m_Camera.transform.position;

        if ((Position.x - Camera.x) < -7f)
        {
            Camera.x = Position.x + 7f;
        }

        if ((Position.x - Camera.x) > 7f)
        {
            Camera.x = Position.x - 7f;
        }

        m_Camera.transform.position = Camera;
    }
}
