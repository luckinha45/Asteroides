using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{
    public AudioSource laserBeamSFX;
    public AudioSource astExplosionSFX;

    // Start is called before the first frame update
    void Start()
    {
        laserBeamSFX = Instantiate(Resources.Load("Audios/laser-beam")) as AudioSource;
        astExplosionSFX = Instantiate(Resources.Load("Audios/explosion")) as AudioSource;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playLaserBeam()
	{
        laserBeamSFX.Play();
    }

    public void playAsteroidExplosion()
	{
        astExplosionSFX.Play();
	}
}
