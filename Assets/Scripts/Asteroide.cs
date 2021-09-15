using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public Rigidbody2D rb;
    private float maxVel = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 direcao = Random.insideUnitCircle * maxVel;
        rb.velocity = direcao;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
