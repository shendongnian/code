    void TargetCheck(GameObject target)
    {
        //Returns true when the sword is over the target
        var CollidedWith = Physics2D.OverlapCircle(transform.position, 0.1f, *LayerYouWantToCollideWith*);
        var TargetCollider2D = target.GetComponent<Collider2D>();
        bool CollidedWithTarget = CollidedWith == TargetCollider2D;
    }
