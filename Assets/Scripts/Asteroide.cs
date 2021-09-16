using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject miniAst;
    public GameObject pollAsteroides;
    public bool isMini;

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
        if(!isMini)
		{
            for(int i = 0; i < 3; i++)
			{
                var miniAstInst = Instantiate(miniAst, transform.position, Quaternion.identity);
                //miniAst.transform.parent;
			}
		}

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
