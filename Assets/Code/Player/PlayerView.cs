using System;
using UnityEngine;


namespace Code.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : MonoBehaviour
    {
        public Animator Animator;
        public Rigidbody Rigidbody;
        public bool isDead = true;
        public bool isGrounded = false;

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
    }
    
    
}