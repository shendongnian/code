        List<GameObject> GameObjects { get; set; }
        List<GameObject> Walls { get; set; }
        List<GameObject> Items { get; set; }
    
        public Map()
        {
            PopulateTiles();
            StructureCollections();
        }
    
        //Small processing loop
        private void DrawObstacles()
        {
            foreach(var wall in Walls)
            {
                Console.SetCursorPosition(tile.X, tile.Y);
                Console.Write("#");
            }
        }
    
        //Called only on startup
        private  void PopulateTiles()
        {
            for (int x = 1; x < 159; x++)
                for (int y = 3; y < 45; y++)
                    GameObjects.Add(new GameObject() { X = x, Y = y });
        }
    
        //Called only on starup
        private void StructureCollections()
        {
            foreach(GameObject gameObj in GameObjects)
            {
                if (gameObj.IsWall)
                    Walls.Add(gameObj);
    
                if (gameObj.IsItem)
                    Items.Add(gameObj);
            }
        }
