using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

    private Rigidbody2D rb;

    public float mTurnSpeed;
    public float mThrust;

    public Transform arrowPoint;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {


	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Transform trans = rb.transform;
        float angle = Mathf.Deg2Rad * trans.eulerAngles.z;
        float angleTan = Mathf.PI - Mathf.Atan2(-rb.velocity.y, rb.velocity.x);

        //print(" TANangle  " + angleTan * Mathf.Rad2Deg + " shipAngle " + angle * Mathf.Rad2Deg + "  and dif: " + Mathf.Rad2Deg * (angleTan - angle));
        arrowPoint.eulerAngles = new Vector3(Vector3.forward.x, Vector3.forward.y, Vector3.forward.z * angleTan * Mathf.Rad2Deg);

        if (v > .75)
        {
            float angleThrust = Mathf.Deg2Rad * trans.eulerAngles.z;
            rb.AddForce(new Vector2(Mathf.Cos(angleThrust) * v * mThrust, Mathf.Sin(angleThrust) * mThrust * v));

        }

        else if (v < -.75)
        {
            if (rb.velocity.magnitude > .1)
            {
                 if (Mathf.Abs(Mathf.Rad2Deg * (angle - angleTan)) > 1)
                {
                    if ((Mathf.Rad2Deg * (angleTan - angle) +360 ) % 360 > 180)
                    {
                        h = 1f;
                    }
                    else
                    {
                        h = -1f;
                    }
                }
                else
                {
                    //print("velocity mag:  " + rb.velocity.magnitude);
                    rb.AddForce(new Vector2(Mathf.Cos(angleTan) * mThrust * -v, Mathf.Sin(angleTan) * mThrust * -v));
                }
            }
        }
    


        rb.angularVelocity = h * -mTurnSpeed;
    }
}
