    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class MazeGenerator: MonoBehaviour {
    
        public GameObject wallObjectRoot;
        public GameObject wallObjectReference;
        public float wallLength = 1.0f;
        public int xSize = 5;
        public int ySize = 5;
    
        private Vector3 initialPos;
    
        // Use this for initialization
        void Start ()
        {
            if (wallObjectReference == null || wallObjectRoot == null){
                Debug.LogError("WallHolder properties need to be assigned to MazeGenerator");
            }
    
            CreateWalls();  
        }
    
        // Update is called once per frame
        void Update () {
    
        }
    
        void CreateWalls()
        {
          
    
            initialPos = new Vector3((-xSize / 2) + wallLength / 2, (-ySize / 2) + wallLength / 2);
           
            //For x axis
            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j <= xSize; j++)
                {
                    Vector3 spawnPos = new Vector3(initialPos.x + (j * wallLength) - wallLength / 2, 0.0f, initialPos.z + (i * wallLength) - wallLength / 2);
                    GameObject wallObject = Instantiate(wallObjectReference, spawnPos, Quaternion.identity);
                    wallObject.transform.parent = wallObjectRoot.transform;
                }
            }
    
            //for y axis
            for (int i = 0; i <= ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {
                    Vector3 spawnPos = new Vector3(initialPos.x + (j * wallLength), 0.0f, initialPos.z + (i * wallLength) - wallLength);
                    GameObject wallObject = Instantiate(wallObjectReference, spawnPos, Quaternion.Euler(0.0f, 90.0f, 0.0f));
                    wallObject.transform.parent = wallObjectRoot.transform;
                }
            }
      
        }
    }
