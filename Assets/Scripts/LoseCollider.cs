using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] int countBalls = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(countBalls);

        if(countBalls <= 1)
        {
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            countBalls--;
            Destroy(collision.gameObject);
        }
    }

    public void AddBalls(int count)
    {
        countBalls += count;
    }

    public void DecreseCountBalls()
    {
        countBalls--;
    }
}
