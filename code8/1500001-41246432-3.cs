       // define the content of ItemsControl
        public class ICContent
        {
            public BindingList<UCContent> UCContentList { get; set; }
        }
    
        // define the content of 1 UserControl
        public class UCContent
        {
            public string GeneralStuff { get; set; }
            public BindingList<AllRowsDetails> RowDetails { get; set; }
        }
    
        // define all the datagrid rows for each UserControl
        public class AllRowsDetails
        {
            public string CodeClient { get; set; }
            public string columnA { get; set; }
            public string columnB { get; set; }
        }
