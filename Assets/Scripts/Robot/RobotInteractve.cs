using UnityEngine;

public class RobotInteractve : MonoBehaviour
{
    [SerializeField] private GameObject intersctive;
    public void OpenInteractive()
    {
        intersctive.SetActive(true);
    }
    public void ClosedInteractive()
    {
        intersctive.SetActive(false);
    }
}
