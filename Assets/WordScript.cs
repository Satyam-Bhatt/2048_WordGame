using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WordScript : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up);
        Gizmos.DrawRay(transform.position, transform.right);
        Gizmos.DrawRay(transform.position, -transform.up);
        Gizmos.DrawRay(transform.position, -transform.right);

        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, 1f);
    }

    private void Update()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1f);

        
    }
}
