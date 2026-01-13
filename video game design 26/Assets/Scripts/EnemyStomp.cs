using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weak Point")
        {
            Destroy(collision.gameObject);
        }
    }
}
