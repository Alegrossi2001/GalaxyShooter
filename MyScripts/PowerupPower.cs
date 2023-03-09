using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPower : MonoBehaviour
{
    private PlayerShoot shootEnabled;
    private PlayerScript speedEnabled;
    private enum powerupId
    {
        tripleShot,
        speedBoost,
        shield
    }
    [SerializeField] private powerupId powerID;
    [SerializeField] private AudioSource powerupSound;

    private void Awake()
    {
        shootEnabled = GameObject.Find("Player").GetComponent<PlayerShoot>();
        speedEnabled = GameObject.Find("Player").GetComponent<PlayerScript>();
        powerupSound = GameObject.Find("PowerupSFX").GetComponent<AudioSource>();
        if (shootEnabled == null)
        {
            UnityEngine.Debug.LogError("Player is null");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            switch ((int)powerID)
            {
                case 0: shootEnabled.TripleShot();
                    break;
                case 1: speedEnabled.SpeedBoost();
                    break;
                case 2: speedEnabled.ShieldUp();
                    break;
            }
            //shootEnabled.TripleShot();
            powerupSound.Play();
            Destroy(this.gameObject);
        }
    }
}
