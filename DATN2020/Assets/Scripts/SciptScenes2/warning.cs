using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class warning : MonoBehaviour
{
    // Start is called before the first frame update
    public Gamemaster gm;
    private TextMeshProUGUI uiText;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<Gamemaster>();
        uiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.Inputtext.text = ("                                                      The bridge will collapse"); 
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.Inputtext.text = ("");
           
        }
    }
}
