using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private float horizontalInput;
    private float verticalInput;
    private float xBound = 11.3f;
    private float yBound = 3.8f;
    public int lives = 3;
    private SpawnManager spawnManager;
    private bool speedBoostEnabled;
    private bool shieldEnabled;
    private GameOver gameManager;
    [SerializeField] private GameObject shield;


    // Start is called before the first frame update
    void Start()
    {
        //place the player's position at (0,0,0)
        transform.position = new Vector3(0, 0, 0);
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameOver>();
        if(spawnManager == null)
        {
            UnityEngine.Debug.LogError("Spawn manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        
    }

    void CalculateMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        if(speedBoostEnabled == true){
            transform.Translate(direction * Time.deltaTime * speed * 2);
        }
        else
        {
            transform.Translate(direction * Time.deltaTime * speed);
        }
        

        //restrain on player pos y
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -yBound, 0), 0);

        //restrain player pos on x
        if (transform.position.x >= xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, 0);
        }
        else if (transform.position.x <= -xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, 0);
        }
    }

    public void ShieldUp()
    {
        shield.SetActive(true);
        shieldEnabled = true;
    }

    public void Damage()
    {
        if (shieldEnabled == true)
        {
            shieldEnabled= false;
            shield.SetActive(false);
            return;
        }
        else
        {
            lives--;

            if (lives < 1)
            {
                spawnManager.OnPlayerDeath();
                Destroy(this.gameObject);
                gameManager.IsGameOver();
            }
        }

    }

    public void SpeedBoost()
    {
        speedBoostEnabled = true;
        StartCoroutine(SpeedBoostPowerDown());
    }

    IEnumerator SpeedBoostPowerDown()
    {
        yield return new WaitForSeconds(5.0f);
        speedBoostEnabled = false;
    }
}
