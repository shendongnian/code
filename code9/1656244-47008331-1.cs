    public void GenerateMap()
    {
        GameObject GO;
        for (int column = 0; column < 10; column++) {
            for (int row = 0; row < 10; row++) 
            {
                GO = Instantiate (HexPrefab, new Vector3 (column, 0, row), Quaternion.identity) as GameObject; 
                GO.transform.parent = this.transform;
            }
        }
    }
