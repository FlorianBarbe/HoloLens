using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Four"))
        {
            gameManager.AddIngredient();
            gameObject.SetActive(false);
        }
    }
}