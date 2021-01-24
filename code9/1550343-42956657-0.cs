       using System;
       using System.Collections.Generic;
       using System.Linq;
      using System.Threading.Tasks;
    namespace UKSF.Models
    {
        public class MainViewModel
        {
            public MainViewModel()
            {
               Newss = new List<News>();
            }
            public List<News> Newss { get; set; }
        }
    }
