     void OnCollisionEnter2D (Collision2D colInfo)
     {
         if (colInfo.relativeVelocity.magnitude > health)
         {
             StartCoroutine(Die());
         }
     }
     IEnumerator Die ()
     {
         Instantiate(deathEffect, transform.position, Quaternion.identity);
         EnemiesAlive--;
         if (EnemiesAlive <= 0)
         {
             Debug.Log ("LEVEL WON!");
             yield return StartCoroutine (delay()); //delay here
             loadToScene = 1;
             SceneManager.LoadScene (loadToScene);
         }
         Destroy(gameObject);
     }
