		protected override async void OnAppearing()
		{
		   listClass.ItemsSource = list;
		   listClass.ItemTemplate = new DataTemplate(Function) ; 
		}
		public object Function()
		{
			return new ItemTemplateViewCell (Navigation);
		}
