using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class space_upgrades : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text priceText;
    public TMP_Text IncomeInfoText;

    [Header("Gen values")]
    public int startPrice = 15;
    public float upgradePriceMult;
    public float SCPerUpgrade;

    [Header("Manager")]
    public GameManager gameManager;

    int level;

    private void Start()
    {
        UpdateUI();
    }

    public void ClickAction()
    {
        int price = CalculatePrice();
        bool purchaseSuccess = gameManager.PurchaseAction(price);
        if (purchaseSuccess)
        {
            level++;
            UpdateUI();
        }
    }

    void UpdateUI(){
        priceText.text = CalculatePrice().ToString();
        IncomeInfoText.text = level.ToString() + " x " + SCPerUpgrade + "/s";
    }

    int CalculatePrice()
    {
        int price = Mathf.RoundToInt(startPrice * Mathf.Pow(upgradePriceMult, level));
        return price;
    }
    public float CalculateIncomePerSecond(){
        return SCPerUpgrade * level;
    }
}