using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject prefabCirculo;
    public float speed = 10.0f;
    public float angle = 0.0f;

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
        float hori = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vert = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position += new Vector3(hori, vert, 0);
    }

    void shoot()
	{
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefabCirculo, transform.position, transform.rotation);
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
