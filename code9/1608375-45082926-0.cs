    private readonly List<string> collidingTags = new List<string>();
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Add some kind of filter or safety check if needed
        collidingTags.Add(collider.tag);
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        //Add some kind of safety check if needed
        collidingTags.Remove(collider.tag);
    }
