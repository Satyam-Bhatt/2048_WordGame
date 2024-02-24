using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class WordScript : MonoBehaviour
{
    [SerializeField] private string letter;
    [SerializeField] private GameObject number_2;
    [SerializeField] private float radius = 1f;

    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, 2f);
    }

    private void Update()
    {
        bool destroyMe = false;

        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D col in collider)
        {
            if(col.transform.root != transform)
            {
                TMP_Text text = col.GetComponentInChildren<TMP_Text>();
                if (text.text == letter)
                {
                    Destroy(col.gameObject);
                    Instantiate(number_2, transform.position, Quaternion.identity);
                    destroyMe = true;
                }
            }
        }

        if(destroyMe)
        {
            foreach (Collider2D col in collider)
            {
                Destroy(col.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
