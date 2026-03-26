using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class evolutions : MonoBehaviour
{
    public Button base_evo;
	public Button evo;
	public Button evo_upgrade;

	[Header("Components")]
    public TMP_Text priceText;
    public TMP_Text IncomeInfoText;

    [Header("Gen values")]
    public int startPrice = 15;
	public float countPerEvo;

	[Header("Manager")]
	public GameManager gameManager;

	public bool isUnlocked = false;
	int level = 1;

	private void Start(){
		UpdateUI();
	}

	void OnButtonClicked()
	{
		base_evo.gameObject.SetActive(false);
		evo.gameObject.SetActive(true);
		evo_upgrade.interactable = false;
	}

	public void ClickAction()
	{
    	int price = CalculatePrice();
    	bool purchaseSuccess = gameManager.PurchaseAction(price);
     	if (purchaseSuccess)
      	{
        	OnButtonClicked();
         	isUnlocked = true;
       	}
	}

	void UpdateUI()
	{
		priceText.text = CalculatePrice().ToString();
	}

	int CalculatePrice()
	{
		int price = Mathf.RoundToInt(startPrice);
		return price;
	}

	public float CalculateCount()
	{
		return countPerEvo * level;
	}
}