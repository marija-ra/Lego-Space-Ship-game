using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KolekcijaZvijezda : MonoBehaviour
{
     public static int zvijezde = 0;

    void Start()
    {
        zvijezde = 0;

    }
    

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            zvijezde++;
            
            

            print("pokupio");
            Instantiate(Resources.Load("pokupioEfekat"),this.transform.position, this.transform.rotation);

            Destroy(this.gameObject);

        }
    }


}
