        public class MyItemData
        {
            public string ItemCode { get; set; }
            public string BarCode { get; set; }
            //etc...
        }
    public class MyBL
    {
        public MyItemData GetItemData(string itemCode)
        {
            var myDL = new MyDBLayer();
            var itemDataSet = myDL.ReturnItemData(itemCode);
    
            var newItem = new MyItemData();
            newItem.ItemCode = itemCode;
            newItem.BarCode = itemDataSet.Tables[0].Rows[0]["BarCode"].ToString();
    
            //etc...
    
            return newItem;
        }
    }
    
    
    public class MyDBLayer
    {
        public DataSet ReturnItemData(string itemCode)
        {
            DataSet myDataSet;
            //Query database and set dataSet
            return myDataSet;
        }
    }
