using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AmmoBar : MonoBehaviour
{

    #region Singleton
    public static AmmoBar singleton;
    private void Awake()
    {
        singleton = this;
    }
    #endregion

    [Header("Bullets")]
    public Image[] bullets;

    public void UpdateAmmoBar(int ammo)
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (i < ammo)
            { bullets[i].gameObject.SetActive(true); }
            else
            { bullets[i].gameObject.SetActive(false); }
        }
    }

    public void RefreshAmmoBar(int ammo, int stack)
    {
        Color black = new Color(0.15f, 0.15f, 0.15f, 1);
        Color white = new Color(1, 1, 1, 1);

        print("Ammo:" + ammo + " Stacks:" + stack);

        for (int i = 0; i < stack; i++)
        {
            if (i < ammo)
            {
                bullets[i].color = white;
            }
            else
            {
                bullets[i].color = black;
            }
        }
    }
}
