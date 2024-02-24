using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberScript : MonoBehaviour
{
    private TMP_Text myText;
    [SerializeField] private GameObject number_4;
    [SerializeField] private GameObject number_6;
    [SerializeField] private float radius = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D col in collider)
        {
            if(col.transform.root != transform)
            {
                TMP_Text text = col.GetComponentInChildren<TMP_Text>();
                if (text != null && text.text == "3" && myText.text == "3")
                {
                    Destroy(col.gameObject);
                    Instantiate(number_6, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                else if (text != null && text.text == "2" && myText.text == "2")
                {
                    Destroy(col.gameObject);
                    Instantiate(number_4, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }
    }
}
