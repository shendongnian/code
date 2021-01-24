    List<dataObj> data = new List<dataObj>();
    for (var row = 1; row <= rw; row++)
    {
        for (var column = 1; column <= cl; column++)
        {
            dataObj d = new dataObj();
            d.DeniedSourceIp = dtblData.Rows[row - 1]["YourColNameOfDeniedSourceIp"].ToString();
            d.Count = int.Parse(dtblData.Rows[row - 1]["YourColNameOfCount"].ToString());
            data.Add(d);
        }
    }
    struct dataObj
    {
        public string DeniedSourceIp { get; set; }
        public int Count { get; set; }
    }
