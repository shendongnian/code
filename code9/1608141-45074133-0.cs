        public UserRegistration()
		{
			InitializeComponent();
			Title = "HomePage";
			//Connecting context of this page to the our View Model class
			this.BindingContext = App.Locator.Register;
		}
