using UnityEngine;
using TMPro;

public class FoodCollection : MonoBehaviour
{
    public int foodCount = 0;

    public TextMeshProUGUI foodText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foodCount++;
            foodText.text = "Food: " + foodCount.ToString();
            Destroy(gameObject);
        }
    }
}
