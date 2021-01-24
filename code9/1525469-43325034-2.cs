    void OnTriggerEnter2D(Collider2D target) 
    {
        if(target.tag == "Top")
            Destroy(gameObject);
        else if(target.tag == "Ball")
        {
            target.GetComponent<Ball>().IsHit();    // We know this component should exist when the object is tagged "Ball"
            Destroy(gameobject);
        }
    }
