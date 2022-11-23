using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PostavaBehaviourScript utocnikScript = this.GetComponentInParent<PostavaBehaviourScript>();
        PostavaBehaviourScript cilScript = collision.GetComponent<PostavaBehaviourScript>();

        if (cilScript != null && utocnikScript != cilScript)
        {
            utocnikScript.Utok(cilScript);
        }
    }
}
