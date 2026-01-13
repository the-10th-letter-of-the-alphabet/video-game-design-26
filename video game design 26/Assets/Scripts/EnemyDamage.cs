using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;

    public float pushForce;

    public PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * pushForce, ForceMode.Impulse);
            }
        }
    }
}
