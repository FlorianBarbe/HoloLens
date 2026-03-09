using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int ingredientCount = 0;
    public int targetCount = 5;

    public GameObject successText;

    public void AddIngredient()
    {
        ingredientCount++;

        if (ingredientCount >= targetCount)
        {
            successText.SetActive(true);
        }
    }
}