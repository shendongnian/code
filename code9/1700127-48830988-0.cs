    public class PageModel  
    {
        public PageModel()
        {
            Chart = new List<ChartGroups>();
        }
       
        public string Title {get; set;}
        public List<ChartGroups> Chart { get; set; } 
    }
   
    
