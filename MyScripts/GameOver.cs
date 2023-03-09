using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);
                isGameOver= false;
            }

        }
    }

    public void IsGameOver()
    {
        isGameOver = true;
    }
}
