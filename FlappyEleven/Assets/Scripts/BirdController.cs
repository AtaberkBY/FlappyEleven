using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BirdController : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;

    private int score;
    public Text tmp;
    public Text livesText;
    public GameObject gameoverPanel;
    private Animator animator;
    public int lives = 3;
    private bool isInvincible = false;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = gameoverPanel.GetComponentInChildren<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Score")
        {
            score++;
            tmp.text = score.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Death" && !isInvincible)
        {
            lives--;
            livesText.text = lives.ToString();
            
        }
        if(lives <= 0)
        {
            gameoverPanel.SetActive(true);
            animator.Play("Surprise");
            Time.timeScale = 0;
        }
        else
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }
    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Pipes"), true);

        float duration = 1.5f;
        float blinkInterval = 0.1f;

        for (float t = 0; t < duration; t += blinkInterval)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }

        sr.enabled = true;
        isInvincible = false;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Pipes"), false);
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}

