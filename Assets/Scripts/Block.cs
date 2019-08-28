using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprite;

    // cached reference
    Level level;
    GameSession gameSession;

    // state variables
    [SerializeField] int timesHit; //SF only for debug

    bool isWasCollision = false; // Only one colision per block
    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        CountBreakableBlocks();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tag == "Breakable")
        {
            HandleHit();
        }
    }
    //&& !isWasCollision  
      //      isWasCollision = true;
    //
    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprite.Length + 1;
        if (timesHit >= maxHits )
        {

            if(!isWasCollision)
            {
                isWasCollision = true;
                TriggerExtraBalls();
                DestroyBlock();
            }

        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprite[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];

        }
        else
        {
            Debug.LogError("Block sprite is missing from array " +  gameObject.name);
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

    private void TriggerExtraBalls()
    {
        if (GetComponent<ExtraBalls>() != null)
        {
            GetComponent<ExtraBalls>().AddExtraBalls();
        }
    }
}
