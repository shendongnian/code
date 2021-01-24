     void OnCollisionEnter(Collision exampleCol) {
         if(exampleCol.collider.tag == "Wall")
         {
             SceneManager.LoadScene("Game Over");
         }
     }
