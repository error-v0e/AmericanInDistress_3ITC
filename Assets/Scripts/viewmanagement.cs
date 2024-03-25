using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class viewmanagement : MonoBehaviour
{
    public int wood = 0;
    public int money = 0;

    public TextMeshProUGUI woodText;
    public TextMeshProUGUI moneyText;


    private void UpdateUI()
    {
        if (woodText != null)
            woodText.text = "Døevo: " + wood;

        if (moneyText != null)
            moneyText.text = "Peníze: " + money;
    }
    public void AddWood(int amount)
    {
        wood += amount;
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }
    public void RemoveMoney(int amount)
    {
        money -= amount;
        UpdateUI();
    }
    public void RemoveWood(int amount)
    {
        wood -= amount;
        UpdateUI();
    }

    void Start()
    {
        UpdateUI();
    }
}