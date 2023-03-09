using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject tripleshotPrefab;
    [SerializeField] private AudioSource laserSFX;
    private Vector3 offset = new Vector3(0f,1.3f, 0f);
    private float canfire = -1f;
    private float fireRate = 0.5f;
    private bool tripleShotEnabled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canfire)
        {
            FireLaser();
        }
       
    }

    void FireLaser()
    {
        canfire = Time.time + fireRate;
        if(tripleShotEnabled)
        {
            Instantiate(tripleshotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(laserPrefab, transform.position + offset, Quaternion.identity);
        }

        laserSFX.Play();

    }

    public void TripleShot()
    {
        tripleShotEnabled= true;
        StartCoroutine(TripleShotPowerDown());
    }

    IEnumerator TripleShotPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        tripleShotEnabled= false;
    }
}
