    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using CrossTest_V2.Models;
    
    namespace CrossTest_V2.ViewModels
    {
        public class CrossViewModel : DbContext
        {
            public List<Cross> Crosses { get; set; }
            public List<C203_Reference_Numbers> Refnr { get; set; }
            public List<C203_Reference_Numbers> Refnr2 { get; set; }
            public List<C400_Article_Search_Tree_Allocation> C400 { get; set; }
            public List<C400_Article_Search_Tree_Allocation> C400_2 { get; set; }
        }
    }
