using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("Ball").Length);
        if(GameObject.FindGameObjectsWithTag("Ball").Length <= 1)
        {
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
