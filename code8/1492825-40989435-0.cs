    IEnumerator SpawnBalls () {
        Vector3[] ballArray = new Vector3[ballNumber];
        Vector3 spawnPosition = new Vector3 ();
        int index = 0;
        
        for (int i = 0; i < ballNumber; i++) {
            // Create first ball and store coordinates into our ballArray at index 0
            if (i == 0) {
                spawnPosition = Random.insideUnitCircle.normalized * 0.7f; 
                Instantiate (ball, spawnPosition, Quaternion.identity);
                Debug.Log ("wolo");
                ballArray[index] = spawnPosition;
            // Else we already have one ball
            } else if (i > 0) {
                // Create new spawn coordinates
                spawnPosition = Random.insideUnitCircle.normalized * 0.7f;
                // Loop through indicies of array that have been filled
                while ( int k = 0; k <= index; k++ ) {
                  // Check that each value in array meets distance requirement
                  if(Vector3.Distance (spawnPosition, ballArray[k]) <= 0.3f) {
                    // If not, create new coordinates and reset k
                    spawnPosition = Random.insideUnitCircle.normalized * 0.7f;
                    k = 0;
                  }
                }
                // Update array
                ballArray[index++] = spawnPosition;
                
                Instantiate (ball, spawnPosition, Quaternion.identity);
                Debug.Log ("yolo");
            }
            }
            yield return null;
        }
