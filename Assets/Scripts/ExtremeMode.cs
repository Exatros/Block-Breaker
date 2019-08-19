using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtremeMode : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject newBall = Instantiate(Ball, transform.position, transform.rotation);
            MoveNewBall(newBall);
        }

    }

    private void MoveNewBall(GameObject ball)
    {
        ball.GetComponent<Rigidbody2D>().velocity = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>().velocity.normalized * -15f;
    }
}
