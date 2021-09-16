using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject prefabProjetil;
    public Rigidbody2D rb;
    public GameObject deathScreen;

    private float acceleration = 5.0f;
    private float maxSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void FixedUpdate()
	{
        lookAtMouse();
		
        move();
	}

	// Update is called once per frame
	void Update()
    {
        shoot();
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
            var shoot = Instantiate(prefabProjetil, pos, transform.rotation);
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

	private void OnDestroy()
	{
        Text nPontos = GameObject.Find("Canvas/nPontuacao").GetComponent<Text>();

        int pts = System.Convert.ToInt32(nPontos.text);
        pts -= 250;
        nPontos.text = System.Convert.ToString(pts);

        Debug.Log(nPontos.text);

        deathScreen.SetActive(true);
	}

    private void OnBecameInvisible()
    {
        float x = transform.position.x;
        if (x > 13)
        {
            x = -14;
        }
        else if (x < -13)
        {
            x = 14;
        }

        float y = transform.position.y;
        Debug.Log(y);
        if (y > 5)
        {
            y = -6;
        }
        else if (y < -5)
        {
            y = 6;
        }

        transform.position = new Vector3(x, y, 0);
    }
}
