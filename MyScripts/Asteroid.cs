using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 3.0f;
    [SerializeField] private GameObject explosion;
    private SpawnManager spawnManager;
    private AudioSource explosionSFX;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        explosionSFX = GameObject.Find("ExplosionsSFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed);  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            explosionSFX.Play();
            spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.2f);
        }
    }
}
