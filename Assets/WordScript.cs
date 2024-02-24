using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class WordScript : MonoBehaviour
{
    [SerializeField] private string letter;
    [SerializeField] private GameObject number_2;

    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, 1f);
    }

    private void Update()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1f);

        foreach (Collider2D col in collider)
        {
            if(col.transform.root != transform)
            {
                TMP_Text text = col.GetComponentInChildren<TMP_Text>();
                if (text.text == letter)
                {
                    Instantiate(number_2, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
