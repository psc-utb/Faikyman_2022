using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class KnightController : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    Rigidbody2D _rigidbody2D;
    Animator _animator;

    bool _utoci = false;
    bool _muzeSeHybat = true;

    GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        sword = transform.Find("Sword").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1")
            && _utoci == false)
        {
            _animator.SetTrigger("Attack");
            _utoci = true;
            _muzeSeHybat = false;
        }

        if (_muzeSeHybat)
        {
            float vx = CrossPlatformInputManager.GetAxisRaw("Horizontal");

            bool isMoving = false;
            if (vx != 0)
            {
                isMoving = true;
            }

            _animator.SetBool("Moving", isMoving);

            if (isMoving)
            {
                _rigidbody2D.velocity = new Vector2(vx * speed, _rigidbody2D.velocity.y);
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
            }
        }
        else
        {
            _animator.SetBool("Moving", false);
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    public void ZacatekUtoku()
    {
        sword.SetActive(true);
    }

    public void KonecUtoku()
    {
        _utoci = false;
        _muzeSeHybat = true;

        sword.SetActive(false);
    }


    public void LateUpdate()
    {
        Vector2 localScale = transform.localScale;

        if (localScale.x > 0 && _rigidbody2D.velocity.x < 0
            || localScale.x < 0 && _rigidbody2D.velocity.x > 0)
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }
}
