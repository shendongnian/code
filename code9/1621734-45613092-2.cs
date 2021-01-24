    public class WallSpawner : MonoBehaviour
    {
        // Prefab
        public GameObject ObstaclePrefab;
        // Origin point (first row, first obstacle)
        public Vector3 Origin;
        // "distance" between two rows
        public Vector3 VectorPerRow;
        // "distance" between two obstacles (wall segments)
        public Vector3 VectorPerObstacle;
        // How many rows to spawn
        public int RowsToSpawn;
        // How many obstacles per row (including the one we skip for the gap)
        public int ObstaclesPerRow;
	    void Start ()
	    {
	        Random r = new Random();
            // loop through all rows
	        for (int row = 0; row < RowsToSpawn; row++)
	        {
                // randomly select a location for the gap
	            int gap = r.Next(ObstaclesPerRow);
	            for (int column = 0; column < ObstaclesPerRow; column++)
	            {
	                if (column == gap) continue;
                    // calculate position
	                Vector3 spawnPosition = Origin + (VectorPerRow * row) + (VectorPerObstacle * column);
                    // create new obstacle
	                GameObject newObstacle = Instantiate(ObstaclePrefab, spawnPosition, Quaternion.identity);
                    // attach it to the current game object
	                newObstacle.transform.parent = transform;
	            }
	        }
	    }
    }
