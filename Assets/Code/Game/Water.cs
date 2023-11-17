using System;
using UnityEngine;

public class Water : MonoBehaviour
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
