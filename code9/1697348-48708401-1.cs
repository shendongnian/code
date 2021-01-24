    Gameobject myCube;
    void OnCollisionEnter(Collision collision) {
         if (collision.collider.tag == "Cubicle")
         {
             Debug.Log(collision.gameObject.name + " hit!");
             myCube = collision.gameObject; // store colliding gameobject info for use elsewhere
         }
     }
