using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Robot : MonoBehaviour
{
    public event UnityAction Died;
    
    public void SetPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
