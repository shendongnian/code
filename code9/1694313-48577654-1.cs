    public DataTable DTforReport()
    {
        DataTable testTable = new DataTable("Test");
        testTable.Columns.Add("OrderNo");
        testTable.Columns.Add("OrderQuantity");
        testTable.Columns.Add("BarcodeQR");
        string[] lines = File.ReadAllLines("C:\\Users\\abc\\Desktop\\abc.txt");
        foreach (var line in lines)
        {
            DataRow dRow = testTable.NewRow();
            var segments = line.Split(';');
            for (int i = 0; i < segments.Length; i++)
            {
                var colValues = segments[i].Split(':');
                dRow[i] = colValues[1];
            }
            testTable.Rows.Add(dRow);
        }
        return testTable;
    }
