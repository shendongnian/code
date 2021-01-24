    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Brick")){
             Destroy(collision.gameObject);
             if (brickList.Containt(collision.gameObject)) {
                 brickList.Remove(collision.gameObject);
             }
       }
    }
