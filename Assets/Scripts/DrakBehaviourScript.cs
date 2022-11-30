using hrdina_a_drak.Postavy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrakBehaviourScript : PostavaBehaviourScript
{
    protected new void Awake()
    {
        postava = new Drak(jmeno, zdravi, maxPoskozeni, maxObrana);
        postava.DosloKUtoku += Postava_DosloKUtoku;
    }

    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
    }
}
