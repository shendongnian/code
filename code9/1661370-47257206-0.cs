    void OnCollisionEnter2D (Collision2D collider)
    {
        if (collider.gameObject.tag == "wall") {
    		turn = !turn;
        }
    }
