    void Spawn ()
        {
            if(playerHealth.currentHealth <= 0f)
            {
                return;
            }
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);
            Object o = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation); // only one
            EnemyManager.Instance.EnemyList.Add(o.GetInstanceID(), o);
           ((GameObject)o).GetComponent<EnemyHealth>().EnemyHealthHandler += ScoreManager.EnemyHealthEvent;
        }
