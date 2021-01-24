    public class RPGCharacter
    {
       private int health;
       public int Health
       {
           get { return health; }
           set {
                 health = value;
                 if(health <= 0)
                     ResetGame();
               }
       }
       
    }
