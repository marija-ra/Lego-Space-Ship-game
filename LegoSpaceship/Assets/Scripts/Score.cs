using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    public Text zvijezdeCount;
    public Text medoCount;

    

    void Start()
    {
        
        zvijezdeCount.text = "Zvijezde: 0";

        medoCount.text = "Medo: 0";
    }

    
    void Update()
    {
        

        zvijezdeCount.text = "Zvijezde: " + KolekcijaZvijezda.zvijezde;
        medoCount.text = "Medo: " + LaserPucanje.brojPogodjenihMeda;
    }
}
