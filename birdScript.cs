using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class birdScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocity = 1;
    private Rigidbody2D rb;

    public static int scoreNumber = 0;

    public TextMeshProUGUI inGameScoreText;

    public GameObject gameOverCanvas;

    public Animator birdAnim;
    void Start()
    {
        scoreNumber = 0;
        rb = GetComponent<Rigidbody2D>();

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            birdAnim.Play("birdFlap");
            rb.velocity = Vector2.up * velocity;
        }

        inGameScoreText.text = scoreNumber.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreNumber++;
    }

    public void playAgain()
    {
        SceneManager.LoadScene(0);
    }
}
