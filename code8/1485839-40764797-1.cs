    public Tag SelectedTag 
    {
      get {...}; 
      set 
        {  
            _selectedTag = value ;
            SelectedData = value!=null?_selectedTag.Data:null;
            //call notifypropertychanged here...    
        }
    }; 
    
    public Data SelectedData {get {...}; set {....}};
