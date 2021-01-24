    public class EnemySpawnScript : MonoBehaviour {
	
    public void enemySpawn (GameObject player, LevelData level){
		StartCoroutine(InstantiateObjects(player, level.enemyDataSpawner));
        }
        IEnumerator InstantiateObjects (GameObject player, IEnumerable<EnemyDataSpawn> enemyDataSpawnList){
	    	foreach(var enemyDataSpawn in enemyDataSpawnList){
			    while( /* too many enemies of enemyDataSpawn type */ ) {
	    			yield return new WaitForSeconds(enemyDataSpawn.delay);
    			}
			    // instantiate enemyDataSpawn
		    }
		
        }
    }
