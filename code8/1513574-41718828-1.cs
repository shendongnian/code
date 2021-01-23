        public IEventAggregator iEventAggregator;
       public  event PropertyChangedEventHandler PropertyChanged;
       
       public static string name;
       public static string dept;
       public static string grade;
    
       [Bindable(true)]
       public  string Naam
       {
           get { return name; }
           set
           { 
            name = value;
            OnPropertyChanged("Naam");
           }
       }
       [Bindable(true)]
       public string Grade
       {
           get { return grade; }
           set
           {
              
                   grade = value; OnPropertyChanged("Grade");
              
           }
       }
       [Bindable(true)]
       public string Dept
       {
           get { return dept; }
           set
           {
              
                   dept = value;
                   OnPropertyChanged("Dept");
              
           }
       }
       public Details(IEventAggregator eventaggregator)
       {
           InitializeComponent();
           this.iEventAggregator = eventaggregator;
           iEventAggregator.GetEvent<Itemselectedevent>().Subscribe((str) => { Naam = str; });
           iEventAggregator.GetEvent<gradeevent>().Subscribe((str) => { Grade = str; });
           iEventAggregator.GetEvent<deptevent>().Subscribe((str) => { Dept = str; });          
           this.DataContext = this;           
       }
     
       protected void OnPropertyChanged(string s)
       {
             PropertyChangedEventHandler handler = PropertyChanged;          
             if (handler != null)
             {
                 handler(this, new PropertyChangedEventArgs(s));
             }            
       }
       private void Button_Click_1(object sender, RoutedEventArgs e)
       {  
         Application.Current.Shutdown();
       }      
    }
