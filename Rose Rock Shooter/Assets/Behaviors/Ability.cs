using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability  {

    [Header("Info")]
    public string abilityName;
    public string abilityDescription;
    public Sprite abilitySprite;

    [Header("Ability")]
    public GameObject ability;
    public float abilityCooldown;
    public int spawnInt;
    public int abilityStack;
    public bool isDisabled;

}
