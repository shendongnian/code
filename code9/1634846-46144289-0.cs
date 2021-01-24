    Tile[,] Tiles;
    string[] mapData;
    public void LoadMap(string path)
    {
        if (File.Exists(path))
        {
            mapData = File.ReadAllLines(path);
            
            var width = mapData[0].Split(',').Length;
            var height = mapData.Length;
            Tiles = new Tile[width, height];
            using (StreamReader reader = new StreamReader(path))
            {
                for (int y = 0; y < height; y++)
                {
                    string[] charArray = mapData[y].Split(',');
                    for (int x = 0; x < charArray.Length; x++)
                    {               
                        int value = int.Parse(charArray[x]);
                        ...
                        Tiles[x, y] = new Tile(SpriteSheet, 5, 3, new Vector2(x * 64, y * 64));
                    }
                }
            }
        }
    }
