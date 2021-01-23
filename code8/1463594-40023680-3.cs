    public List<Tuple<int, String>> listQuality { get; set; }
    		public Tuple<int, String> qualityChoose { get; set; }
    
    		public MainWindow()
    		{
    			InitializeComponent();
    			listQuality = new List<Tuple<int, string>>();
    			listQuality.Add(new Tuple<int, string>(0, "Fastest"));
    			listQuality.Add(new Tuple<int, string>(1, "Fast"));
    			listQuality.Add(new Tuple<int, string>(2, "Simple"));
    			listQuality.Add(new Tuple<int, string>(3, "Good"));
    			listQuality.Add(new Tuple<int, string>(4, "Beautiful"));
    			listQuality.Add(new Tuple<int, string>(5, "Fantastic"));
    
    			this.DataContext = this;
    		}
    
    		private void Button_Click(object sender, RoutedEventArgs e)
    		{
    			int quality = qualityChoose.Item1;
    		}
