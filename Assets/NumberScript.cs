using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberScript : MonoBehaviour
{
    private TMP_Text myText;
    
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1f);

        foreach (Collider2D col in collider)
        {
            if(col.transform.root != transform)
            {
                TMP_Text text = col.GetComponentInChildren<TMP_Text>();
                if (text != null && text.text == myText.text)
                {
                    Debug.Log("found Number");
                }
            }
        }
    }
}
