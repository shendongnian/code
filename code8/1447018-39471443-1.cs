    public class QueryViewModel
    {
        public DateTime displayDate {get; set;}
        public int Count1 {get; set;}
        public int count2 {get; set;}
    }
     public class QueryView
     {
        public IEnumerable<QueryViewModel> DateList =new IEnumerable<QueryViewModel>();
        public IEnumerable<Date1> Date1 { get; set; }
        public IEnumerable<Date1> Date2 { get; set; }
        
        public  fillDates()
        {
           QueryViewModel qvm=new QueryViewModel()          
           int i=0;
           foreach(var item in Date1.Reverse())
           {
              qvm.displayDate = theDate;
              qvm.Count1  = theCount;
             DateList.Add(qvm);
           }
           int i=0;
           foreach(var item in Date2.Reverse())
           {
              DateList[i].Count2  = theCount;
              i++;
           }
           return DateList
        }
     }
