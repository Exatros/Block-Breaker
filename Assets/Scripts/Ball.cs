﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 0f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //state
    Vector2 paddleToBalVector;
    public static bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;
    LoseCollider loseCollider;

    // Start is called before the first frame update
    void Start()
    {
        loseCollider = FindObjectOfType<LoseCollider>();
        if (GameObject.FindGameObjectsWithTag("Ball").Length <= 1)
        {
            paddleToBalVector = transform.position - paddle1.transform.position;
        }
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

        if(transform.position.y < -5)
        {
            loseCollider.DecreseCountBalls();
            Destroy(gameObject);
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBalVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(-randomFactor,randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
            myRigidbody2D.velocity = myRigidbody2D.velocity.normalized * 15;
        }
    }
}
