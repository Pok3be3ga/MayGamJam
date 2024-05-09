using UnityEngine;

public class FloorButtons : MonoBehaviour
{
    [SerializeField] Door _door;
    [SerializeField] Color _doorColor;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = _doorColor;
        _door.GetComponent<SpriteRenderer>().color = _doorColor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _door.Open();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _door.Close();
    }
}
