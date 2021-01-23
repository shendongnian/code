    void OnTriggerEnter(Collider col)
     {
    
         if (col.name == "head")
         {
             //Run My Code
             Debug.Log("Head Triggered!");
         }
         else if (col.name == "hand")
         {
             //Run My Code
             Debug.Log("Hand Triggered!");
         }
         else if (col.name == "leg")
         {
             //Run My Code
             Debug.Log("Leg Triggered!");
         }
     }
