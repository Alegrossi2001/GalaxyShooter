using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    [SerializeField] private float powerupSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // move down at speed of 3
        transform.Translate(Vector3.down * Time.deltaTime * powerupSpeed);
        if(transform.position.y < -4)
        {
            Destroy(this.gameObject);
        }

    }
}
