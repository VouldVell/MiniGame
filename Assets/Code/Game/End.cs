using System;
using UnityEngine;

namespace Code.Game
{
    public class End : MonoBehaviour
    {
        public event Action OnTriggered;
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnTriggered?.Invoke();
            }
        }
    }
}