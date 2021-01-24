    private List<Collider2D> collided = new List<Collider2D>();
    public void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.CompareTag("Player") && !collided.Contains(col.collider)) {
            collided.Add(col.collider);
            // ...    
