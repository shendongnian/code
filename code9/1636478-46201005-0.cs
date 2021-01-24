	protected override async void OnAppearing()
	{
		listClass.ItemsSource = list;
		listClass.ItemTemplate = new DataTemplate(typeof(ItemTemplateViewCell )); 
	}
	public class ItemTemplateViewCell : ViewCell
	{
		Label NameLbl = new Label();
		StackLayout sLayout = new StackLayout ();
		Button btnViewcell = new Button {Text = "Show class details"};
		public ItemTemplateViewCell()
		{
			NameLbl.SetBinding(Label.TextProperty, "Name");
			sLayout.Children.Add(NameLbl);
			btnViewcell.Clicked += (s, e) =>
			{
				App.Current.MainPage.Navigation.PushAsync(new Home());
			};
			sLayout.Children.Add(btnViewcell);
			this.View = sLayout;
		}
	}
