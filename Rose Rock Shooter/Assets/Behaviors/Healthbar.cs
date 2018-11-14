using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Healthbar : MonoBehaviour {

    #region Singleton
    public static Healthbar singleton;
    private void Awake()
    {
        singleton = this;
    }
    #endregion

    [Header("UIElements")]
    public Image[] bars;
    public Sprite filled;
    public Sprite empty;
    public Sprite firstFill;
    public Sprite firstEmpty;


    public void SetHealth(int health)
    {
        for (int i = 0; i < bars.Length; i++)
        {
            if (i == 0)
            {
                if (health > i)
                { bars[i].sprite = firstFill; }
                else
                { bars[i].sprite = firstEmpty; }
            }
            else
            {
                if (health > i)
                { bars[i].sprite = filled; }
                else
                { bars[i].sprite = empty; }
            }
        }
    }

}
