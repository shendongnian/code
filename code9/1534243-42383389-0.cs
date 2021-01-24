    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
    public static DataTableData GetData()
    {
    
       List<string[]> list = new List<string[]>();
       DataTableData data = new DataTableData();
       data.data = new List<string[]>();
    
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "1" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "2" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "3" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "4" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "5" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "6" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "7" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "8" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "9" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "10" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "11" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "12" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "13" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "14" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "15" });
       list.Add(new string[] { "Mairaj", "Ahmad", "Minhas", "16" });
    
       int start = 0;
       int length = 0;
       int draw = 0;
       int.TryParse(HttpContext.Current.Request.QueryString["start"].ToString(), out start);
       int.TryParse(HttpContext.Current.Request.QueryString["length"].ToString(), out length);
                int.TryParse(HttpContext.Current.Request.QueryString["draw"].ToString(), out draw);
    
       data.draw = draw;
       var filter = list.Skip(start).Take(length).ToList();
       data.data = filter;
    
       data.recordsFiltered = list.Count;
       data.recordsTotal = list.Count;
       return data;
    }
    public class DataTableData
    {
      public int draw { get; set; }
      public int recordsTotal { get; set; }
      public int recordsFiltered { get; set; }
      public List<string[]> data { get; set; }
    
     }
