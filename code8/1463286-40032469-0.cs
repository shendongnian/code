    //This no longer includes Visits, because they aren't specific to a CustomerType
    public class CustomerType
    {
      public string CustomerTypeDescription { get; set; }
      public int CustomerCount { get; set; }
    }
    
    //This is now the ViewModel used by the View:
    public class DashboardViewModel
    {
       public List<CustomerType> CustomerTypes { get; set; }
       public List<View_VisitorsForm> Visits { get; set; }
    }
