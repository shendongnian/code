    Vector3 newPos = rb.position;
     if (rightHit.collider != null) 
     {
         //...
             {
                 newPos -= Xspeed * Time.fixedDeltaTime;      
             }
         //...
     }
     if (downHit.collider != null)
     {
         //...
             {
                 newPos += Yspeed * Time.fixedDeltaTime;      
             }
         //...
     }
     rb.MovePosition(newPos);
