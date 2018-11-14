using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{

    [Header("Stats")]
    public int health;
    public int maxHealth = 100;
    public int attackDamage = 5;

    [Header("Misc")]
    public bool flashAnim = true;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer == null)
        {
            print("No SpriteRenderer can be found on " + transform.name);
        }

        health = maxHealth;
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else if (flashAnim)
        { Flash(); }
    }

    private void Flash()
    {
        Color color = spriteRenderer.color;
        int cycles = 6;
        bool visible = true;

        for (int i = 0; i < cycles; i++)
        {
            if(visible)
            {
                color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
                visible = false;
            }
            else
            {
                color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
                visible = true;
            }
            spriteRenderer.color = color;

        }

    }


}
