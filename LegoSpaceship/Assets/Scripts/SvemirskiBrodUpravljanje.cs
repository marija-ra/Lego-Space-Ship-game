using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvemirskiBrodUpravljanje : MonoBehaviour
{
    Rigidbody svemirskiBrod;

    void Awake()
    {
        Cursor.visible = false;

        svemirskiBrod = GetComponent<Rigidbody>();
    }

  
    void FixedUpdate()
    {

        PomjeranjeGoreDole();
        PomjeranjeNaprijed();
        Rotiranje();
        OgranicavanjeBrzine();
        Skretanje();

        
        svemirskiBrod.AddRelativeForce(Vector3.up * sila);
        svemirskiBrod.rotation = Quaternion.Euler(
             new Vector3(nagibNaprijed, trenutnaYRotacija, tiltAmountSideways)
             );
    }



    private float sila;
    void PomjeranjeGoreDole()
    {
        float y = Input.GetAxis("Vertical");
        y = Mathf.Clamp01(y);


        if (Input.GetAxis("Vertical") > 0.2f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K))
            {
                svemirskiBrod.velocity = svemirskiBrod.velocity;
            }

            if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L))
            {
                svemirskiBrod.velocity = new Vector3(svemirskiBrod.velocity.x, Mathf.Lerp(svemirskiBrod.velocity.y, 0, Time.deltaTime * 5), svemirskiBrod.velocity.z);
                sila = 400;
            }
            
            if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
            {
                svemirskiBrod.velocity = new Vector3(svemirskiBrod.velocity.x, Mathf.Lerp(svemirskiBrod.velocity.y, 0, Time.deltaTime * 5), svemirskiBrod.velocity.z);
                sila = 400;
            }
            if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
            {
                sila = 410;
            }

        }

        if ((Input.GetAxis("Vertical") < 0.2f && Input.GetAxis("Vertical") > 0.0f) || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            sila = 135;
        }

        if (Input.GetKey(KeyCode.I))
        {
            sila = 450;
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
            {
                sila = 500;
            }
        }

        
        else if (Input.GetKey(KeyCode.K))
        {
            sila = -200;
        }
        else if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f))
        {
            sila = 98.1f;
        }
       

    }

    
    private float nagibNaprijed = 0;
    private float nagibVelocity;
    public float brzina = 80.0f;

    void PomjeranjeNaprijed()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            sila = 100;
            svemirskiBrod.velocity = svemirskiBrod.velocity;
            svemirskiBrod.AddRelativeForce(Vector3.forward * Mathf.Abs(Input.GetAxis("Vertical")) * brzina);
            //nagibNaprijed = Mathf.SmoothDamp(nagibNaprijed, 2f * Input.GetAxis("Vertical"), ref nagibVelocity, 0.01f);
        }
    }

    private float zeljenaYRotacija;
    [HideInInspector] public float trenutnaYRotacija;
    private float rotacijaKorak = 2.5f;
    private float rotacijaYVelocity;
    void Rotiranje()
    {
        if (Input.GetKey(KeyCode.J))
        {
            zeljenaYRotacija -= rotacijaKorak;
        }
        if (Input.GetKey(KeyCode.L))
        {
            zeljenaYRotacija += rotacijaKorak;
        }

        trenutnaYRotacija = Mathf.SmoothDamp(trenutnaYRotacija, zeljenaYRotacija, ref rotacijaYVelocity, 0.25f);
    }

    private Vector3 velocityToZero;
    void OgranicavanjeBrzine()
    {
        if (Input.GetAxis("Vertical") > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            svemirskiBrod.velocity = Vector3.ClampMagnitude(svemirskiBrod.velocity, Mathf.Lerp(svemirskiBrod.velocity.magnitude, 10.0f, Time.deltaTime * 2f));
        }
        if (Input.GetAxis("Vertical") > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            svemirskiBrod.velocity = Vector3.ClampMagnitude(svemirskiBrod.velocity, Mathf.Lerp(svemirskiBrod.velocity.magnitude, 10.0f, Time.deltaTime * 2f));
        }
        if (Input.GetAxis("Vertical") < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            svemirskiBrod.velocity = Vector3.ClampMagnitude(svemirskiBrod.velocity, Mathf.Lerp(svemirskiBrod.velocity.magnitude, 5.0f, Time.deltaTime * 2f));
        }
        if (Input.GetAxis("Vertical") < 0.2f  && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            svemirskiBrod.velocity = Vector3.SmoothDamp(svemirskiBrod.velocity, Vector3.zero, ref velocityToZero, 0.95f);
        }
        

    }

    private float sideMovementAmount = 300.0f;
    private float tiltAmountSideways;
    private float tiltAmountVelocity;
    void Skretanje()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {

            //svemirskiBrod.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovementAmount);
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -20 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
        }
    }
}
