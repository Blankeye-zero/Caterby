using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeafCollection : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int leaves = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Leaf")) {
            Destroy(collision.gameObject);
            leaves++;
            text.text = "Leaves: "+ leaves;
            Debug.Log(leaves);
        }
    }
}
