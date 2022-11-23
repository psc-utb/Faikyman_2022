using hrdina_a_drak.Postavy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HrdinaBehaviourScript : PostavaBehaviourScript
{
    private void Awake()
    {
        postava = new Hrdina(jmeno, zdravi, maxPoskozeni, maxObrana);
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
