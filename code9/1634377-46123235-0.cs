    float Alpha = 0;
    void OnCollisionEnter2D (Collision2D col) {
    
            Alpha += 1f / maxHits;
            currentHit++;
            gameObject.GetComponent<SpriteRenderer> ().color = new Color(159f/255,86f/255,86f/255,Alpha);
            if (currentHit == maxHits) {
                Destroy (gameObject);
            }
    }
