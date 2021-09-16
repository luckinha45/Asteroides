using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroide : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject miniAst;
    public bool isMini;
    //public GameObject nPontos;

    private float maxVel = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 direcao = Random.insideUnitCircle * maxVel;
		//Vector2 direcao = new Vector2(0,3);

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
                Instantiate(miniAst, transform.position, Quaternion.identity);
            }
		}

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

	private void OnDestroy()
	{
        Text nPontos = GameObject.Find("Canvas/nPontuacao").GetComponent<Text>();

        int pts = System.Convert.ToInt32(nPontos.text);
        pts += 250;
        nPontos.text = System.Convert.ToString(pts);

        Debug.Log(nPontos.text);
	}

	private void OnBecameInvisible()
	{
        float x = transform.position.x;
        if(x > 13)
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
