using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBelt : MonoBehaviour
{
    [Header("Passive")]
    public Ability passive;

    [Header("Abilities")]
    public List<Ability> abilities = new List<Ability>(4);

    private float abilityMainCD;
    private float abilityOneCD;
    private float abilityTwoCD;
    private float abilityUltimateHolyFuckItsAllOverAbilityCD;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            FireMain();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            FireAbilityOne();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            FireAbilityTwo();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            FireUltimateHolyFuckItsAllOverAbility();
        }
    }

    private void FireMain()
    {
        if (abilityMainCD <= 0)
        {
            Instantiate(abilities[0].ability, transform.position, Quaternion.identity);
            abilityMainCD = abilities[0].abilityCooldown;
        }
        else
        {
            print("Ability on CoolDown");
        }
    }

    private void FireAbilityOne()
    {
        if (abilityOneCD <= 0)
        {
            Instantiate(abilities[1].ability, transform.position, Quaternion.identity);
            abilityMainCD = abilities[1].abilityCooldown;
        }
        else
        {
            print("Ability on CoolDown");
        }
    }

    private void FireAbilityTwo()
    {
        if (abilityTwoCD <= 0)
        {
            Instantiate(abilities[2].ability, transform.position, Quaternion.identity);
            abilityMainCD = abilities[2].abilityCooldown;
        }
        else
        {
            print("Ability on CoolDown");
        }
    }

    private void FireUltimateHolyFuckItsAllOverAbility()
    {
        if (abilityUltimateHolyFuckItsAllOverAbilityCD <= 0)
        {
            Instantiate(abilities[3].ability, transform.position, Quaternion.identity);
            abilityMainCD = abilities[3].abilityCooldown;
        }
        else
        {
            print("Ability on CoolDown");
        }
    }

}
