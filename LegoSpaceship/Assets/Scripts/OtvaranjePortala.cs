using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtvaranjePortala : MonoBehaviour
{

    public GameObject zid;
    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (KolekcijaZvijezda.zvijezde == 17)
        {
            portal.SetActive(true);
            Destroy(zid);            

        }
    }
}
