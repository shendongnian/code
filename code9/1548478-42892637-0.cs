    for (int i = demiSpace; i < Terrain.SIZE; i = i + espace)        
    {
        for (int j = demiSpace; j < Terrain.SIZE; j = j + espace)
        {
            var avg = Terrain.HeightMap[i + demiSpace, j + demiSpace] +
                        Terrain.HeightMap[i + demiSpace, j - demiSpace] +
                        Terrain.HeightMap[i - demiSpace, j + demiSpace] +
                        Terrain.HeightMap[i - demiSpace, j - demiSpace];
            avg /= 4;
            Terrain.HeightMap[i, j] = Normalize(avg + r.Next() % decalage);
        }
    }
