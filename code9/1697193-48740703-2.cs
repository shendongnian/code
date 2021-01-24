     public static string mycolor { get; set; } = "Red";  
     public MainPage()
     {
         this.InitializeComponent();
         this.DataContext = mycolor;
         ...
     }
