using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndaDeAsteroides : MonoBehaviour
{
    public Asteroide prefabAsteroide;
    private int n_asteroides;

    // Start is called before the first frame update
    void Start()
    {
        n_asteroides = 3;

        float x = Random.Range(-14, 14);
        float y = Random.Range(-5, 5);

        Vector3 pos = new Vector3(x, y, 0);

        for(int i = 0; i < n_asteroides; i++)
		{
            Instantiate(prefabAsteroide, pos, Quaternion.identity);
		}
    }
}
