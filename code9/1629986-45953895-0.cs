    var tempFilePath = Path.GetTempFileName();
    using (var writer = File.CreateText(tempFilePath))
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (j > 0)
                    writer.WriteLine(" ");
                writer.Write(InventoryArray[i, j]);
            }
            writer.WriteLine();
        }
    }
