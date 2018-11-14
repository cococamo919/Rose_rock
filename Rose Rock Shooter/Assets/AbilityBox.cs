using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class AbilityBox : MonoBehaviour
{
    [Header("UIElements")]
    public Sprite abilitySprite;
    public Image coolDownSprite;
    public TextMeshProUGUI timer;

    public void UpdateAbilityBox(float cd, float maxCD)
    {
        timer.text = cd.ToString("0.00");
        coolDownSprite.fillAmount = cd / maxCD;

        CheckVisualQue(cd);
    }


    void CheckVisualQue(float cd)
    {
        if (cd > 0)
        {
            coolDownSprite.gameObject.SetActive(true);
            timer.gameObject.SetActive(true);
        }
        else
        {
            coolDownSprite.gameObject.SetActive(false);
            timer.gameObject.SetActive(false);
        }
    }
}
