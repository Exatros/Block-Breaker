using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    // cached reference
    Level level;
    GameSession gameSession;

    // state variables
    [SerializeField] int timesHit; //SF only for debug

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        CountBreakableBlocks();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        TriggerSparklesVFX();
        UpdateGameSession();
        Destroy(gameObject);
    }

    private void UpdateGameSession()
    {
        gameSession.AddToScore();
        level.BlockDestroyed();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }
}
