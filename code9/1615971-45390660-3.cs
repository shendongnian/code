    using MyApp.Models;
    namespace MyApp.ViewModels
    {
      public class ParentChildViewModel
        {
          public int parent_id { get; set; }
          public string parent_name { get; set; }
          public string parent_address { get; set; }
          public IEnumerable<Child> children { get; set; }
        }
    }
