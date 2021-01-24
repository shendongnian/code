    public class Enemy:MonoBehaviour
    {
         private static int enemyCount = 0;
         public static int EnemyCount {get{ return enemyCount;} }
         public event Action<int> RaiseEnemyDeath;
         public static void ResetEnemyCount(){
              enemyCount = 0;
         }
         private int health;
         public void Damage(int damage)
         { 
             CheckForDamage(); // here you check that damage is not neg or too big...
             this.health -= damage;
             if(this.health <= 0)
             { 
                 OnDeath(); 
             }
         }
         void OnActivate() 
         { 
             enemyCount++; 
             this.health = 20;
         }
         void OnDeath()
        { 
             enemyCount--; 
             RaiseEnemyDeath(enemyCount); // Should check for nullity...
        }
    }
