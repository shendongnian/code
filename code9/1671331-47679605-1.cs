     // <summary>
    // Demo cusotm object
    // </summary>
    public class MyObject
    {
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        //  Bind RadGrid         
        RadGrid1.DataSource = this.GetData();
    }
    // <summary>
    // Returns a Demo custom object DataSource
    // </summary>
    // <returns></returns>
    private List<MyObject> GetData()
    {
        List<MyObject> data = new List<MyObject>();
        for (int i = 0; (i <= 100); i++)
        {
            var item = new MyObject();
            item.ItemNumber = i;
            item.ItemName = ("Item # " + i);
            data.Add(item);
        }
        return data;
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        RadGrid1.MasterTableView.FilterExpression = "([ItemName] LIKE \'%1%\')";
        RadGrid1.Rebind();
    }
