using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Words;

    private int counter = 0;

    private void Start()
    {
        foreach (GameObject word in Words)
        {
            word.SetActive(false);
        }
        Words[counter].SetActive(true);
        counter++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Words[counter].SetActive(true);
            counter++;
        }   
    }
}
