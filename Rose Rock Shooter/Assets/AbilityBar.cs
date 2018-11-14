using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBar : MonoBehaviour {

    #region Singleton
    public static AbilityBar singleton; 
    private void Awake()
    {
        singleton = this;
    }
    #endregion

    [Header("AbilityBoxes")]
    public AbilityBox[] boxes;
    
}
