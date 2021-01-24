    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Brick_Spawn_Test : MonoBehaviour {
        [SerializeField]
        private int totalBrickColumns = 9; // Serializing it so I can use this for multiple test cases and edit the variable in the inpsector.
        [SerializeField]
        private int totalBrickRows = 2;
        [SerializeField]
        private Vector2 startingPoint = new Vector2(-4, 0);
        [SerializeField]
        private GameObject Brick;
    
        void Start()
        {
            CreateBricks();
        }
    
        void CreateBricks()
        {
           Vector2 spawnPosition = startingPoint;
    
           for(int x = 0; x < totalBrickColumns; ++x) // x is my column 
           {
               spawnPosition.x = startingPoint.x + x;  // the x is my offset from the startingPoint.x so if I wanted to start at -4 i just set the startingPoint.x to -4
               for(int y = 0; y < totalBrickColums; ++y) // y is my row
               { 
                   spawnPosition.y = startingPoint.y + y; // the y is my offset from the startingPoint.y
                   print("Brick Location: " + spawnPosition.toString());
                   Instantiate(Brick,spawnPosition, transform.rotation);
               }
            }
        }
    }
