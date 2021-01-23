    data = activeWorksheet.UsedRange.Value2;    
    string[,] newData = new string[data.GetLength(0), data.GetLength(1)];
    for (int x = 0; x < data.GetLength(0); x++)
    {
      for (int y = 0; y < data.GetLength(1); y++)
      {
        newData[x, y] = data[x + 1, y + 1].ToString();
      }
    }
    var df = Frame.FromArray2D(newData);
