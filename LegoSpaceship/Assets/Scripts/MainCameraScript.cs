using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    private Transform svemirskiBrod;

    void Awake()
    {
        svemirskiBrod = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private Vector3 velocityCameraFollow;
    public Vector3 pozicijaKamere = new Vector3(-1.2f , 0.2f, -5.5f);
    public float ugao = 20;
    void FixedUpdate()
    {
        float y = Input.GetAxis("Vertical");
        
        if (y <= 0)
        {
            transform.position = Vector3.SmoothDamp(transform.position, svemirskiBrod.transform.TransformPoint(pozicijaKamere), ref velocityCameraFollow, 0.1f);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, svemirskiBrod.transform.TransformPoint(pozicijaKamere) + Vector3.up * y, ref velocityCameraFollow, 0.1f);
        }
        
        transform.rotation = Quaternion.Euler(new Vector3(ugao, svemirskiBrod.GetComponent<SvemirskiBrodUpravljanje>().trenutnaYRotacija, 0));

    }
}
