using System;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Animator playerAnimator;
    Vector3 velocity;
    public TextMeshProUGUI playerScore;
    public int score;
    int highScore;
    public float movespeed;
    public float jumpspeed, jumpFrequency, nextJumpTime;
    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    bool facingRight = true;
    

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        score = 0;
        UpdateScore();
    }


    void Update()
    {
        playerScore.text = "Score: " + score.ToString();
        HorizontalMove();
        OnGroundCheck();

        if (velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
        if (velocity.x < 0 && facingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime<Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }
    void HorizontalMove()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += velocity * movespeed * Time.deltaTime;
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        rigidbody2D.AddForce(new Vector2(0f, jumpspeed));
    }
    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGrounded", isGrounded);
    }

    public void AddScore(int amount)
    {
        score += amount;
        ScoreManager.currentScore = score;
        UpdateScore();
    }

    public void UpdateScore()
    {
        playerScore.text = "Score: " + score;
    }
    public void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            highScore = score;
        }
    }
}
