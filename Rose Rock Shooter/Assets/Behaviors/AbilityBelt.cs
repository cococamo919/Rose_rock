using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBelt : MonoBehaviour
{
    [Header("Passive")]
    public Ability passive;

    [Header("Abilities")]
    public List<Ability> abilities = new List<Ability>(4);

    [Header("FirePoint")]
    public Transform firePoint;
    public Transform alternateFirePoint;

    [Header("Debug")]
    public bool multiFire;
    public float fireDelay;
    public float mainCD;
    public float oneCD;
    public float twoCD;
    public float ultimateHolyFuckItsAllOverAbilityCD;

    private float abilityMainCD;
    private float abilityOneCD;
    private float abilityTwoCD;
    private float abilityUltimateHolyFuckItsAllOverAbilityCD;

    private SpawnPool spawnPool;

    private void Start()
    {
        spawnPool = GetComponentInChildren<SpawnPool>();
        if (spawnPool == null)
        {
            print("Ability Belt requires a SpawnPool class to function correctly.");
        }
        else
        { spawnPool.Spawn(abilities[0].ability, abilities[0].spawnInt); }

        abilities[0].stacks = abilities[0].abilityStack;
        AmmoBar.singleton.UpdateAmmoBar(abilities[0].stacks);
    }

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

    private void FixedUpdate()
    {
        if (abilityMainCD > 0)
        {
            abilityMainCD -= Time.deltaTime;
        }

        if (abilityOneCD > 0)
        {
            abilityOneCD -= Time.deltaTime;
            AbilityBar.singleton.boxes[0].UpdateAbilityBox(abilityOneCD, oneCD);
        }

        if (abilityTwoCD > 0)
        {
            abilityTwoCD -= Time.deltaTime;
        }

        if (abilityUltimateHolyFuckItsAllOverAbilityCD > 0)
        {
            abilityUltimateHolyFuckItsAllOverAbilityCD -= Time.deltaTime;
        }
    }

    private void FireMain()
    {
        if (abilityMainCD <= 0)
        {
            if (multiFire)
            { spawnPool.FireDouble(firePoint, alternateFirePoint, fireDelay); }
            else
            { spawnPool.Fire(firePoint); } 
            GetComponent<Animator>().SetTrigger("Fire");
            abilityMainCD = abilities[0].abilityCooldown;
            abilities[0].stacks--;

            if (abilities[0].stacks <= 0)
            {
                abilityMainCD = mainCD * 2;
                abilities[0].stacks = abilities[0].abilityStack;
                GetComponent<Animator>().SetTrigger("Reload");
            }
            else
            {
                abilityMainCD = mainCD;
            }

            AmmoBar.singleton.RefreshAmmoBar(abilities[0].stacks, abilities[0].abilityStack);

        }
        else
        {
            print(abilities[0].abilityName + " on cooldown " + mainCD);
        }
    }

    private void FireAbilityOne()
    {
        if (abilityOneCD <= 0)
        {
            Instantiate(abilities[1].ability, transform.position, Quaternion.identity);
            abilityMainCD = abilities[1].abilityCooldown;
            GetComponent<Animator>().SetTrigger("Fire2");
            abilityOneCD = oneCD;
        }
        else
        {
            print(abilities[1].abilityName + " on cooldown " + oneCD);
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

    void SetCD()
    {
        mainCD = abilities[0].abilityCooldown;
        oneCD = abilities[1].abilityCooldown;
        twoCD = abilities[2].abilityCooldown;
        ultimateHolyFuckItsAllOverAbilityCD = abilities[0].abilityCooldown; 
    }

}
