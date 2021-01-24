    string startRow = "0A";
    string startCol = "B0A";
    RowCol rc = new RowCol("0A", "B0A");
    for (int r = 0; r < rowsCount; r++)
    {
        rc.ColString = "B0A";
        for (int c = 0; c < columnsCount; c++)
        {
            Console.WriteLine(rc);
            rc.Row = rc.Row + 1;
        }
        rc.Col = rc.Col + 1;
    }
