    //Create new class
    public class FinalData
    {
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public string Col4 { get; set; }
    
    	public FinalData(){}
    }
    
    //Populate your two tables into FinalData array as below
    int MaxRows = dt1.Rows.Count > dt2.Rows.Count ? dt1.Rows.Count : dt2.Rows.Count;
    FinalData[] fdList = new FinalData[MaxRows];
    
    for (int i = 0; i < dt1.Rows.Count; i++)
    {
        FinalData[i] = new FinalData() { Col1 = dt1.Rows[i]["Col1"].ToString(), Col2 = dt1.Rows[i]["Col2"].ToString() };
    }
    
    for (int i = 0; i < dt2.Rows.Count; i++)
    {
        FinalData[i] = new FinalData() { Col3 = dt2.Rows[i]["Col3"].ToString(), Col4 = dt1.Rows[i]["Col4"].ToString() };
    }
    
    //Bind your gridview with fdList
    YourGridview.DataSource = fdList;
    YourGridView.DataBind();
