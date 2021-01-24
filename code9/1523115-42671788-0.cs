        //Properties
        CollectionViewSource _CollectionViewSource { get; set; }
        DataTable dt { get; set; }
        
        //Constructor
        public ViewModel() 
        {
            _CollectionViewSource.Source = dt.DefaultView
        } 
    }
