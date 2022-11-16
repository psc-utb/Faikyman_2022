using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class DragonAI : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    Rigidbody2D _rigidbody2D;
    Animator _animator;

    [SerializeField]
    Transform cil;

    [SerializeField]
    float vzdalenostOdCileProUtok = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vzdalenost = cil.position - this.transform.position;
        if (Mathf.Abs(vzdalenost.x) < vzdalenostOdCileProUtok)
        {
            _animator.SetBool("Moving", false);
            _rigidbody2D.velocity = Vector2.zero;
            _animator.SetTrigger("Attack");
        }
        else
        {
            _animator.SetBool("Moving", true);

            _rigidbody2D.velocity = new Vector2(Mathf.Sign(vzdalenost.x) * speed, _rigidbody2D.velocity.y);
        }
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
