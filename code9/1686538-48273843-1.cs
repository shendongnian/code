    static void BulkLoad1()
    {
        string connectionstring = /* your db connection string */
    
        int houseNo = 0;
        using (var xr = new ChoXmlReader("your.xml").WithXPath("/HouseInfo")
            .WithField("HouseNumber", fieldType: typeof(int))
            )
        {
            houseNo = xr.First().HouseNumber;
        }
    
        using (var xr = new ChoXmlReader("your.xml").WithXPath("/HouseInfo/HouseLog/RoomInfo")
            .WithField("HouseNumber", fieldType: typeof(int), valueConverter: (o) => houseNo)
            .WithField("RoomNumber", fieldType: typeof(int))
            .WithField("Timestamp", fieldType: typeof(DateTime))
            .WithField("Color", xPath: "Furnitures/Table/Color", fieldType: typeof(string))
            .WithField("Height", xPath: "Furnitures/Table/Height", fieldType: typeof(string))
            .WithField("Scope", xPath: "ToolCounts/Scope", fieldType: typeof(int))
            .WithField("Code", xPath: "Bathroom/Code", fieldType: typeof(int))
            .WithField("Faucet", xPath: "Bathroom/Faucets", fieldType: typeof(int))
        )
        {
            using (SqlBulkCopy bcp = new SqlBulkCopy(connectionstring))
            {
                bcp.DestinationTableName = "dbo.HOUSEINFO";
                bcp.EnableStreaming = true;
                bcp.BatchSize = 10000;
                bcp.BulkCopyTimeout = 0;
                bcp.NotifyAfter = 10;
                bcp.SqlRowsCopied += delegate (object sender, SqlRowsCopiedEventArgs e)
                {
                    Console.WriteLine(e.RowsCopied.ToString("#,##0") + " rows copied.");
                };
                bcp.WriteToServer(xr.AsDataReader());
            }
        }
