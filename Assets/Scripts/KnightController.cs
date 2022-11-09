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

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vx = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        bool isMoving = false;
        if (vx != 0)
        {
            isMoving = true;
        }

        _animator.SetBool("Moving", isMoving);
    }
}
