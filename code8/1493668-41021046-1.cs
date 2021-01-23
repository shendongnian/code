    public partial class A : System.Web.UI.UserControl
    {   
      public event EventHandler BindDataTotalSummary;
    
      public void MethodA()
      {
          GetDataClass objData = new GetDataClass();
          objData.BindDataTotalSummary();
       }
    }
