    //ctor
    public MyViewModel
    {
        bool IsDesignMode => DesignerProperties.GetIsInDesignMode(new DependecyObject());
    
        public MyViewModel()
        {
           if (IsDesignMode)
           {
              //this will be shown in the designer
              Items = new List<string>{ "Item1", "Item2" }
           }
        }
    
        //INotifyPropertyChanged details ommited due to simplification
        public List<string> Items {get; private set;}
    
        public void Load()
        {
           //optionally you may check IsDesignMode 
           using (var db = new MyDbContext())
           {  
               this.Items = db.Items.Select(i => i.Name).ToList();
           }
        }
    }
