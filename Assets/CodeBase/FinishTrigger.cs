using System;
using Assets.CodeBase;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private bool _triggered;

    public event Action Reached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_triggered)
            return;

        if (collision.attachedRigidbody.TryGetComponent(out Cockroach cockroach))
        {
            Reached?.Invoke();
            _triggered = true;
        }
    }
}
