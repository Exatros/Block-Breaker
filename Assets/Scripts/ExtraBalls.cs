using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBalls : MonoBehaviour
{
    [SerializeField] GameObject Ball;
    [SerializeField] int numberOfExtraBalls = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExtraBalls()
    {
        FindObjectOfType<LoseCollider>().AddBalls(numberOfExtraBalls);
        for (int i = 0; i < numberOfExtraBalls; i++)
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
