    bool hasHitSomething = false;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!hasHitSomething)
        {
            DoSomeDamageTo(other.gameObject);
            hasHitSomething = true;
        }
    }
