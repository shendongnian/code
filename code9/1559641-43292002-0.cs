    public class SomeData
        {
            public  string Data1 { get; set; }
            public string Data2 { get; set; }
    
            public string Color1 { get; set; }
    
            public string Color2 { get; set; }
    
        }
    
     List<SomeData> lstData = new List<SomeData>()
                {
                    
                    new SomeData() {Data1 = "AAA", Color1 = "Red", Data2 = "ZZZ", Color2 = "Green"},
                    new SomeData() {Data1 = "BBB", Color1 = "Blue", Data2 = "PPP", Color2 = "Gold"},
                    new SomeData() {Data1 = "CCC", Color1 = "Red", Data2 = "ZZZ", Color2 = "Yellow"},
    
                };
    
                grdView.DataSource = lstData;
                grdView.DataBind();
