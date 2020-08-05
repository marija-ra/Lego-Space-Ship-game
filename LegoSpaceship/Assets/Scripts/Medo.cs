using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medo : MonoBehaviour
{
    Renderer currentRenderer;
    GameObject first;

    void Awake()
    {
        first = gameObject.transform.GetChild(0).gameObject; 
        first.SetActive(false);


        /*currentRenderer = GetComponentInChildren<Renderer>();*/
        first.GetComponent<Renderer>().enabled = false;
        
       
    }

    void OnTriggerEnter(Collider other)
    {
        //currentRenderer.enabled = true;
        first.GetComponent<Renderer>().enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        //currentRenderer.enabled = false;
        first.GetComponent<Renderer>().enabled = false;
    }
}
