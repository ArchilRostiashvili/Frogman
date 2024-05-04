using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{

    private int Pineapples = 0;

    [SerializeField] private Text PineapplesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            Destroy(collision.gameObject);
            Pineapples++;
            PineapplesText.text = "Pineapples: " + Pineapples;
        }
    }

}
