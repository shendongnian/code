    DataSet definitionsReturned = DataConnection.ExecuteQuery("SELECT DefNum AS reference_id, Category AS category, ItemName AS title, ItemValue AS code from definition WHERE category IN(2,13) ORDER BY category");
    
    MyReturnObject res = new MyReturnObject {
        Data = definitionsReturned,
        Meta = new Metadata {
            FirstRecord = 0,
            LastRecord = 27,
            Page = 1,
            Sync = null
        }
    };
    
    string json = JsonConvert.SerializeObject(res);
