      public float timeLeft=5f;
         
         void FixedUpdate()
         {
             timeLeft -= Time.deltaTime;
             if(timeLeft < 0)
             {
                 DoSomething();
                 timeLeft=5f; //If you want to reset timer 
             }
         }
 
 
