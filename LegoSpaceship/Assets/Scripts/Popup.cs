using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject WinPopup;
    // Start is called before the first frame update
    void Start()
    {
        WinPopup.SetActive(false);
        Cursor.visible = false;

    }
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit(); 
        }
    }

    // Update is called once per frame

    void OnTriggerExit(Collider other)
    {

        if (other.tag == "PortalZid")
        {
            WinPopup.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
    
}
