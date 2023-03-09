using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 4f;
    private UIManager scoreNumber;
    private Animator anim;
    private AudioSource explosionSFX;

    // Start is called before the first frame update
    void Awake()
    {
        scoreNumber = GameObject.Find("Canvas").GetComponent<UIManager>();
        anim = GetComponent<Animator>();
        if(anim == null)
        {
            UnityEngine.Debug.LogError("ANIMATION NOT LOADED CORRECTLY. COMPUTER WILL SHUT DOWN IN 5 SECONDS");
        }
        explosionSFX = GameObject.Find("ExplosionsSFX").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * enemySpeed);
        if (transform.position.y < -4)
        {
            float randomX = UnityEngine.Random.Range(-10, 10);
            transform.position = new Vector3(randomX, 8, 0);
        }
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.name == "Player")
        {
            //damage player
            other.transform.GetComponent<PlayerScript>().Damage();
            anim.SetTrigger("OnEnemyDeath");
            enemySpeed = 0;
            explosionSFX.Play();
            Destroy(this.gameObject, 2.8f);
        }

        else if(other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            //add score
            scoreNumber.score += 10;
            anim.SetTrigger("OnEnemyDeath");
            enemySpeed = 0;
            explosionSFX.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.8f);
        }
    }
}
