        public YourControl(){
            this.InitializeComponent();
                      
            this.DataContext = new MyClassDataContext();
           
       var myContext= (MyClassDataContext)this.DataContext;
          _color=MyContext.MyColorProperty;}
