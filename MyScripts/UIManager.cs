using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float score;
    [SerializeField] private Text scoreText;
    [SerializeField] private Sprite[] lives = new Sprite[4];
    [SerializeField] private Image livesCount;
    [SerializeField] private Text gameOverText;
    private PlayerScript livesLeft;


    // Start is called before the first frame update
    void Start()
    {
        livesLeft = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        livesCount.sprite = lives[livesLeft.lives];
        if (livesLeft.lives == 0)
        {
            gameOverText.gameObject.SetActive(true);
        }

    }

    //add text flicker
}
