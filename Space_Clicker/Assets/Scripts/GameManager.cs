using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text lifetimeText;
    [SerializeField] TMP_Text countText;
    [SerializeField] TMP_Text IncomeText;
	[SerializeField] space_upgrades[] spaceUpgrades;
	[SerializeField] evolutions[] evolutionsUpgrades;
	[SerializeField] float updatePerSecond = 4.99f;

    float count;
    float lifetimeCount;
    float nextTimeCheck = 1;
    float lastIncomeValue;

    private void Start(){
        UpdateUI();
    }

    public void ClickAction()
    {
        float evolutionBonus = 0;
        foreach (var evolution in evolutionsUpgrades)
        {
            if (evolution.isUnlocked)
            {
                evolutionBonus += evolution.CalculateCount();
            }
        }
        count += 1 + evolutionBonus;
        lifetimeCount += 1 + evolutionBonus;
        UpdateUI();
    }

    void Update(){
        if (nextTimeCheck < Time.timeSinceLevelLoad){
            IdleCalculator();
            nextTimeCheck = Time.timeSinceLevelLoad + 1f / updatePerSecond;
        }

    }

	void IdleCalculator()
	{
		float sum = 0;
		foreach (var space_upgrades in spaceUpgrades)
		{
			sum += space_upgrades.CalculateIncomePerSecond();
		}
		lastIncomeValue = sum;
		count += sum / updatePerSecond;
		lifetimeCount += sum / updatePerSecond;
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
        lifetimeText.text = Mathf.RoundToInt(lifetimeCount).ToString() + " lifetime Space Coins";
    }
}