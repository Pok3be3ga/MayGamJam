using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Robot : MonoBehaviour
{
    public event UnityAction Died;
    
    private void Die()
    {
        Died?.Invoke();
    }
}
