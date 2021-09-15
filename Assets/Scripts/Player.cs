using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject prefabCirculo;
    public GameObject tirosPoll;
    private float acceleration = 5.0f;
    public float angle = 0.0f;
    public Rigidbody2D rb;
    private float maxSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookAtMouse();

        shoot();

        move();
    }

    void move()
	{
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");


        rb.AddForce(new Vector2(hori, vert) * acceleration, ForceMode2D.Force);
        if(maxSpeed < rb.velocity.magnitude)
		{
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
		}
    }

    void shoot()
	{
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, 1);
            var shoot = Instantiate(prefabCirculo, pos, transform.rotation);
            shoot.transform.parent = tirosPoll.transform;
        }
    }

    void lookAtMouse()
	{
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);

        transform.rotation = Quaternion.FromToRotation(transform.position, mousePos);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
