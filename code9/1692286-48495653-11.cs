    public class RPGCharacter
    {
       private int health;
       public int Health
       {
           get { return health; }
           set {
                 health = value;
                 if(health <= 0) 
                 {
                     health = 0; // force zero as min value
                     this.Die();
                 }
           }
       }
       void Die() {
           Debug.Log("No more health, you died !");
       }
       
    }
