using UnityEngine;

public class FoodCollection : MonoBehaviour
{
    private int foodCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            foodCount++;
            Destroy(other.gameObject);
        }
    }
}
