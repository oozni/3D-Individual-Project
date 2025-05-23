using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour
{
    public UImanager uiManager;
    Conditions Health { get { return uiManager.health; } }
    Conditions Hunger {  get { return uiManager.hunger; } }
    Conditions Stamina {  get { return uiManager.stamina; } }

    private void Update()
    {
        Passive();
    }

    private void Passive()
    {
        Hunger.Subtract(Hunger.PassiveValueDecrease * Time.deltaTime);

        if (Hunger.CurretValue == 0)
        {
            Health.Subtract(Hunger.PassiveValueDecrease * Time.deltaTime);
        }
        if (Health.CurretValue == 0)
        {
            Die();
        }
    }
    private void HeartPassive()
    {
        if (Health.oneHeart * 3 > Health.CurretValue)
        {
            if (Health.oneHeart * 3 > Health.CurretValue && Health.oneHeart * 2 < Health.CurretValue)
            {
                Health.imageList[0].enabled = false;
            }
            else if (Health.oneHeart * 2 > Health.CurretValue && Health.oneHeart < Health.CurretValue)
            {
                Health.imageList[1].enabled = false;
            }
            else if (Health.oneHeart > Health.CurretValue &&  0 < Health.CurretValue)
            {
                Health.imageList[2].enabled = false;
            }
            else if (0 == Health.CurretValue)
            {
                Health.imageList[3].enabled = false;
            }

        }
    }
    private void Die()
    {
        Debug.Log("Die");
    }
    public  void Heal()
    {

    }
}
