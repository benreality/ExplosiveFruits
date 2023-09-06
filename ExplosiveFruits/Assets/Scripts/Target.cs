using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    private GameManager gameManager;
    public int pointValues;
    public ParticleSystem particles;

    AudioSource audioSourceExplode;
    AudioSource audioSourceSlash;



    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        audioSourceExplode = GameObject.Find("ExplodeAudio").GetComponent<AudioSource>();
        audioSourceSlash = GameObject.Find("SlashAudio").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    //private void OnMouseDown()
    //{
    //    if (gameManager.isGameActive)
    //    {
    //        if (gameObject.CompareTag("Bad"))
    //        {
    //            audioSourceExplode.Play();
    //        }
    //        else
    //        {
    //            audioSourceSlash.Play();
    //        }
    //        Destroy(gameObject);
    //        gameManager.UpdateScore(pointValues);
    //        Instantiate(particles, transform.position, particles.transform.rotation);
            
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.UpdateLives(-1);
        }

    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            if (gameObject.CompareTag("Bad"))
            {
                audioSourceExplode.Play();
            }
            else
            {
                audioSourceSlash.Play();
            }
            Destroy(gameObject);
            gameManager.UpdateScore(pointValues);
            Instantiate(particles, transform.position, particles.transform.rotation);

        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
