using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pacman
{   
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (VirtualInputManager.Instance.MoveRight & VirtualInputManager.Instance.MoveLeft)
            {
                return;
            }
            
            if (VirtualInputManager.Instance.MoveRight)
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                // Using ForceMode.Force (default) for continuous push. 
                // Speed now acts as force strength.
                rb.AddForce(transform.forward * speed);
            }

            if (VirtualInputManager.Instance.MoveLeft)
            {
                transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                rb.AddForce(transform.forward * speed);
            }
        }
    }
}