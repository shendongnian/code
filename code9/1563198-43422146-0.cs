    ICell[,] cells = new ICell[3, 4];
    for (int i = 0; i < cells.GetLength(0); i++)
    {
        for (int j = 0; j < cells.GetLength(1); j++)
        {
            var mock = new Mock<ICell>();
            mock.SetupAllProperties();
            mock.Object.X = i;
            mock.Object.Y = j;
            mock.Object.Value = "";
            cells[i, j] = mock.Object;
        }
    }
    //...other code removed for brevity
