using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class starscript : MonoBehaviour {

    public VRInteractiveItem intItem;
    public Rigidbody rb;
    public float force;
    public float maxLength;
    public GameObject starManager;
    public bool wasHit;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent <Rigidbody>();
        starManager = GameObject.FindWithTag("StarManager");
        maxLength = starManager.GetComponent<StarManager>().maxDistance;
        force = starManager.GetComponent<StarManager>().force;
    }
	
	// Update is called once per frame
	void Update ()
    {
        NormalMove();
        UpdateMove();
    }

    void OnEnable()
    {
        intItem.OnClick += StopStar;
    }

    void OnDisable()
    {
        intItem.OnClick -= StopStar;
    }
    
    void NormalMove() // The normal movement of the star, centered around the origin
    {
        // if went past a certain amount, we stop adding force
        if (!wasHit)
        {
            if ((transform.position - Vector3.zero).magnitude < maxLength)
            {
                rb.AddForce((transform.forward * 1 / (transform.position - Vector3.zero).magnitude * force));
            }
            transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
        }
    }

    void UpdateMove()
    {
        if (Input.GetKey(KeyCode.J)) // pull in and slow down the stars
        {
            rb.AddForce(transform.forward * -force * 2);
        }

        if (Input.GetKey(KeyCode.L)) // push out and speed up the stars 
        {
            rb.AddForce(transform.forward * force * 2);
        }
    }

    // star gets hit
    // star stops, turns white
    public void StopStar()
    {
        print("The star has stopped.");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        wasHit = true;
    }
}
