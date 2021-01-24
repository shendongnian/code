    public class MyClass
    {
        public MyClass()
        {
            this.TargetList = new List<SelectListItem> 
            {
                new SelectListItem { Value = "Android", Text = "Android" },
                new SelectListItem { Value= "WebGL", Text="WebGL" },
                new SelectListItem { Value= "Windows", Text="Windows" },
                new SelectListItem { Value= "IOS", Text="IOS" }
             }
         }
         public IEnumerable<SelectListItem> TargetList
         {  get ; private set; }
    }
        
