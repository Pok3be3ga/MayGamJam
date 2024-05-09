using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool _playerOpen;
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private float _openTime = 1f;
    private Animator _animator;


    private bool _opened;
    private bool _playerContact;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Open()
    {
        _animator.SetTrigger("Open");
        StartCoroutine(CollisionSwitcher(false));
        _opened = true;
    }
    public void Close()
    {
        _animator.SetTrigger("Close");
        StartCoroutine(CollisionSwitcher(true));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_playerOpen && collision.gameObject.GetComponent<Robot>())
        {
            _playerContact = true;
            collision.gameObject.GetComponent<RobotInteractve>().OpenInteractive();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_playerOpen && collision.gameObject.GetComponent<Robot>())
        {
            _playerContact = false;
            collision.gameObject.GetComponent<RobotInteractve>().ClosedInteractive();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ( _opened == false && _playerContact)
            {
                Debug.Log("Open");
                Open();
                _opened = true;
                return;
            }
            else if (_opened == true && _playerContact)
            {
                Debug.Log("Close");
                Close();
                _opened = false;
            }
        }
    }
    IEnumerator CollisionSwitcher(bool collider)
    {
        yield return new WaitForSeconds(_openTime);
        _boxCollider.enabled = collider;
    }
}
