using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // config params
    [Range(0.1f,1f)][SerializeField] float gameSpeed = 0.5f;
    [SerializeField] int pointsPerBloackDestroyed = 2;

    // state variables
    [SerializeField] int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBloackDestroyed; 
    }
}
