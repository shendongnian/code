    var LastSyncDateTime = DateTime.Now;
    
    using (SQLitePCL.SQLiteConnection Conn = new SQLitePCL.SQLiteConnection("BerriaDb.db"))
    {
   
        // use Bind Parameters, that are the @id, @item_name etc
        string sqlInsFoodCode = @"
        INSERT INTO [FoodCode] (
            [ID], 
            [Item_Name], 
            [Code], 
            [ItemID], 
            [FoodCodeID], 
            [Brief_Descriptor], 
            [Full_Descriptor], 
            [Guidesheet], 
            [REG], 
            [Status], 
            [syncDate]) 
        VALUES (
            @id, 
            @item_name, 
            @code, 
            @itemid, 
            @foodcodeid, 
            @brief_descriptor, 
            @full_descriptor, 
            @guidesheet, 
            @reg, 
            @status, 
            @lastsynctime)";
            
        // we can now re use this statement for all inserts
        using (ISQLiteStatement connStatement = Conn.Prepare(sqlInsFoodCode))
        {
            List<FoodCode> ResponseData = wsResponse.data.ToList();
            for (int i = 0; i < ResponseData.Count; i++)
            {
                // just to be sure no values from last time are kept
                connStatement.ClearBindings();
                // bind the values from the Responsedata to the parameters
                connStatement.Bind("@id", ResponseData[i].ID);
                connStatement.Bind("@item_name", ResponseData[i].Item_Name);
                connStatement.Bind("@code", ResponseData[i].Code);
                connStatement.Bind("@itemid", ResponseData[i].ItemID);
                connStatement.Bind("@foodcodeid", ResponseData[i].FoodCodeID);
                connStatement.Bind("@brief_descriptor", ResponseData[i].Brief_Descriptor);
                connStatement.Bind("@full_descriptor", ResponseData[i].Full_Descriptor);
                connStatement.Bind("@guidesheet", ResponseData[i].Guidesheet);
                connStatement.Bind("@reg", ResponseData[i].REG);
                connStatement.Bind("@status", ResponseData[i].Status);
                connStatement.Bind("@lastsynctime", LastSyncDateTime.ToString());
            
                // alwaws take the result ...
                var result = connStatement.Step();
                // ... and check if we're OK, (done in this case)
                if (result != SQLiteResult.DONE) 
                {
                    // if not, yell at the caller
                    throw new Exception(String.Format("ResponseData[{0}].ID('{1}') not inserted. Result: {2}", i, ResponseData[i].ID, result));   
                }
                // enable the re-use of the prepared statement, so call Reset
                connStatement.Reset();               
            }
        }
    }
