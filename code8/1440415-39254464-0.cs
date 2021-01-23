    void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject == Collidor) {
            hit = 1;
        } 
    }
    void OnCollisionExit2D(Collision2D coll){
        if (coll.gameObject == Collidor) {
            hit = 0;
        }
    }
