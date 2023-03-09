using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float laserSpeed = 8f;

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * laserSpeed);
        if(transform.position.y > 8)
        {
            if (transform.parent != null)
            {
                Destroy(this.transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
    

}
