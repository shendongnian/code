        string[] DailyAnimal_array;
        Random r;
  	 private long TimeSpan;
        public MainPage()
        {
            InitializeComponent();
            InitializeArrays();
          
        }
      private void InitializeArrays()
        {
            DailyAnimal_array = new string[200] 
       {
      "BEAR! \r\n … ",
      //etc. 200 total//
      };
      r = new Random(Environment.TickCount);
            r.Next(0);
      private async void AllDailyAnimals_Clicked(object sender, EventArgs args)
        {
            
      var lastTime=CrossSettings.Current.GetValueOrDefault("lastTime", DateTime.MinValue);
           var index = r.Next(0,200);
           
            if ((lastTime + TimeSpan.FromDays(1)) >= DateTime.UtcNow)
            {           
                string DailyAnimal_Text = DailyAnimal_array[index];
                this.DailyAnimal_Text.Text = DailyAnimal_Text;
                CrossSettings.Current.AddOrUpdateValue("lastTime", DateTime.UtcNow);
                CrossSettings.Current.AddOrUpdateValue("index", index);
            }
            else 
            {
                
                index = CrossSettings.Current.GetValueOrDefault("index", index);
                this.DailyAnimal_Text.Text = DailyAnimal_array[0];
            }
            AllDailyAnimals.IsEnabled = false;
            Intro_Image.IsVisible = false;
            AllDailyAnimals.IsVisible = false;
        }
