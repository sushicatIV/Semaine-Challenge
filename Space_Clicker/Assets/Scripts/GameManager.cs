using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] TMP_Text countText;
	[SerializeField] TMP_Text IncomeText;
	[SerializeField] space_upgrades[] spaceUpgrades;
	[SerializeField] float updatePerSecond = 4.99f;
	float count = 0;
	float nextTimeCheck = 1;
	float lastIncomeValue = 0;

	private void Start(){
		UpdateUI();
	}

	public void ClickAction()
	{
		count++;
		UpdateUI();
	}

	void Update(){
		if (nextTimeCheck < Time.timeSinceLevelLoad){
			IdleCalculator();
			nextTimeCheck = Time.timeSinceLevelLoad + 1f / updatePerSecond;
		}

	}

	void IdleCalculator(){
		float sum = 0;
		foreach (var space_upgrades in spaceUpgrades)
		{
			sum += space_upgrades.CalculateIncomePerSecond();
		}
		lastIncomeValue = sum;
		count += sum / updatePerSecond;
		UpdateUI();
	}

	public bool PurchaseAction(int cost){
		if (count >= cost)
		{
			count -= cost;
			UpdateUI();
			return true;
		}
		return false;
	}

	void UpdateUI(){
		countText.text = Mathf.RoundToInt(count).ToString();
		IncomeText.text = lastIncomeValue.ToString() + "/s";
	}



}