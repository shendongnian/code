    void LoadSprite()
    {
        int spriteIndex = 0;
        //Don't decrement if timesHit  is 0
        if (timesHit > 0)
        {
            spriteIndex = timesHit - 1;
        }
        else
        {
            spriteIndex = timesHit;
        }
    
        //Return/Exit function if spriteIndex  is equals or more than hitSprites length
        if (spriteIndex > hitSprites.Length - 1)
        {
            return; 
        }
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
