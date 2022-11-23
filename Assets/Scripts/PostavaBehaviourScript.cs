using hrdina_a_drak.Postavy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PostavaBehaviourScript : MonoBehaviour
{
    [SerializeField]
    protected string jmeno;

    [SerializeField]
    protected int zdravi = 100;

    [SerializeField]
    protected int maxPoskozeni = 10;

    [SerializeField]
    protected int maxObrana = 5;

    protected Postava postava;

    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    public void Utok(PostavaBehaviourScript cilScript)
    {
        postava.Utok(cilScript.postava);
    }
}
