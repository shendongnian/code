    public class GameManager:MonoBehaviour
    {
        void Start()
        {
             Enemy.RaiseEnemyDeath += Enemy_RaiseEnemyDeath;
        }
        void Enemy_RaiseEnemyDeath(int count)
        {
            if(count < 0){ // End of level }
            // You can also access enemyCount
            int count = Enemy.EnemyCount;
        }
    }
