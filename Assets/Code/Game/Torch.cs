using System;
using UnityEngine;

namespace Code.Game
{
    public class Torch : MonoBehaviour
    {
        public event Action OnTriggered;
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                OnTriggered?.Invoke();
            }
        }
    }
}