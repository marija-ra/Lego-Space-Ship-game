using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPucanje : MonoBehaviour
{
    public LineRenderer laserLine1;
    public Transform laserPoint1;
    public Light laserLight1;

    public LineRenderer laserLine2;
    public Transform laserPoint2;
    public Light laserLight2;

    public float fadeSpeed = 1;
    public float laserLength = 10;

    Color laserColor;
    float lightIntesity;

    private RaycastHit hit1;
    private Ray ray1;
    private RaycastHit hit2;
    private Ray ray2;
    private float distance = 10.0f;

    public GameObject obruc;
    public Transform obrucPoint;
    public Rigidbody svemirskiBrod;

    public static int brojPogodjenihMeda = 0;



    void Awake()
    {
        laserColor = laserLine1.material.GetColor("_TintColor");
        lightIntesity = laserLight1.intensity;

        laserLine1.SetPosition(1, Vector3.forward * laserLength);
        laserLine1.useWorldSpace = true;
        laserLight1.intensity = 0;
        laserLine1.material.SetColor("_TintColor", Color.black);

        laserLine2.SetPosition(1, Vector3.forward * laserLength);
        laserLine2.useWorldSpace = true;
        laserLight2.intensity = 0;
        laserLine2.material.SetColor("_TintColor", Color.black);
    }

    
    void Update()
    {
       

        if (Input.GetKey(KeyCode.Q))
        {
            Fire();
        }

        laserLine1.material.SetColor("_TintColor", Color.Lerp(laserLine1.material.GetColor("_TintColor"), Color.black, Time.deltaTime * fadeSpeed));
        laserLight1.intensity = Mathf.Lerp(laserLight2.intensity, 0,Time.deltaTime * fadeSpeed);

        laserLine2.material.SetColor("_TintColor", Color.Lerp(laserLine2.material.GetColor("_TintColor"), Color.black, Time.deltaTime * fadeSpeed));
        laserLight2.intensity = Mathf.Lerp(laserLight2.intensity, 0, Time.deltaTime * fadeSpeed);

    }

    
    void Fire()
    {
        ray1 = new Ray(laserPoint1.position, transform.forward);
        Debug.DrawRay(ray1.origin, ray1.direction * distance, Color.red);

        if (Physics.Raycast(ray1, out hit1))
        {
            if(hit1.distance<distance)
            {
                GameObject medo = hit1.collider.gameObject;
                if (medo.tag == "Medo")
                {                   
                    Destroy(medo);
                    brojPogodjenihMeda++;
                }
            }
        }

        ray2 = new Ray(laserPoint2.position, transform.forward);
        Debug.DrawRay(ray2.origin, ray2.direction * distance, Color.red);

        if (Physics.Raycast(ray2, out hit2))
        {
            if (hit2.distance < distance)
            {
                GameObject medo = hit2.collider.gameObject;
                if (medo.tag == "Medo")
                {
                    Destroy(medo);
                    brojPogodjenihMeda++;
                }
            }
        }

        laserLine1.material.SetColor("_TintColor", laserColor);
        laserLight1.intensity = lightIntesity;

        laserLine2.material.SetColor("_TintColor", laserColor);
        laserLight2.intensity = lightIntesity;

        laserLine1.SetPosition(0, laserPoint1.position);
        laserLine1.SetPosition(1, laserPoint1.position + laserPoint1.TransformDirection(Vector3.forward * laserLength));

        laserLine2.SetPosition(0, laserPoint2.position);
        laserLine2.SetPosition(1, laserPoint2.position + laserPoint2.TransformDirection(Vector3.forward * laserLength));
    }
}
