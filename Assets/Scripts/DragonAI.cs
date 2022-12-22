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

    bool _utoci = false;
    bool _muzeSeHybat = true;

    GameObject mouth;

    //bool cilVlevo = true;
    float smerCile;

    [SerializeField]
    GameObject healthBarUI;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        mouth = transform.Find("Mouth").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (cil != null)
        {
            Vector2 vzdalenost = cil.position - this.transform.position;
            //cilVlevo = Mathf.Sign(vzdalenost.x) <= 0 ? true : false;
            smerCile = Mathf.Sign(vzdalenost.x);
            if (Mathf.Abs(vzdalenost.x) < vzdalenostOdCileProUtok && _utoci == false)
            {
                _animator.SetBool("Moving", false);
                _rigidbody2D.velocity = Vector2.zero;
                _animator.SetTrigger("Attack");
                _utoci = true;
                _muzeSeHybat = false;
            }
            else if (/*_utoci == false &&*/ _muzeSeHybat == true)
            {
                _animator.SetBool("Moving", true);
            }
        }
    }

    public void SetVelocity()
    {
        _rigidbody2D.velocity = new Vector2(smerCile * speed, _rigidbody2D.velocity.y);
    }

    public void LateUpdate()
    {
        Vector2 localScale = transform.localScale;

        if (localScale.x > 0 && smerCile < 0
            || localScale.x < 0 && smerCile > 0)
        {
            localScale.x *= -1;
            if (healthBarUI != null)
                healthBarUI.transform.localScale = new Vector2(healthBarUI.transform.localScale.x * -1, healthBarUI.transform.localScale.y);
        }

        transform.localScale = localScale;
    }

    public void ZacatekUtoku()
    {
        mouth.SetActive(true);
    }

    public void KonecUtoku()
    {
        _utoci = false;
        _muzeSeHybat = true;

        mouth.SetActive(false);
    }

    public void Smrt()
    {
        _animator.SetTrigger("Dead");
        _muzeSeHybat = false;

        mouth.SetActive(false);
    }
}
