using hrdina_a_drak.Postavy;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    protected void Awake()
    {
    }

    public void Postava_DosloKUtoku(Postava utocnik, Postava cil, int utok, int obrana)
    {
        ZobrazTextZasahu(_cilScript.transform.position, utok);
    }

    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    PostavaBehaviourScript _cilScript;
    public void Utok(PostavaBehaviourScript cilScript)
    {
        _cilScript = cilScript;
        postava.Utok(cilScript.postava);
    }

    public void ZobrazTextZasahu(Vector2 poziceZobrazeni, int hodnotaUtoku)
    {
        GameObject goWithText = new GameObject();
        goWithText.name = "Zasah";
        poziceZobrazeni.y = poziceZobrazeni.y + 1;
        goWithText.transform.position = poziceZobrazeni;

        TextMeshPro textMeshPro = goWithText.AddComponent<TextMeshPro>();
        textMeshPro.fontSize = 16;
        textMeshPro.text = (hodnotaUtoku * -1).ToString();
        if (hodnotaUtoku > 0)
        {
            textMeshPro.color = Color.red;
        }
        else if (hodnotaUtoku < 0)
        {
            textMeshPro.color = Color.green;
        }
        else if (hodnotaUtoku == 0)
        {
            textMeshPro.color = Color.blue;
        }
        textMeshPro.renderer.sortingLayerName = "UI";
        textMeshPro.alignment = TextAlignmentOptions.Center;

        var rigidBody2D = goWithText.AddComponent<Rigidbody2D>();
        rigidBody2D.isKinematic = true;
        rigidBody2D.velocity = new Vector2(0, 2);

        GameObject.Destroy(goWithText, 1);
    }
}
