	using System;
	using System.Collections.Generic;
	using Xamarin.Forms;
	namespace ListViewSample
	{
		public class CustomViewCell : ViewCell
		{
			public CustomViewCell()
			{
				View = new Label
			    {
				    Text = "Hello World"
			    };
			}
		}
		public class ListViewContentPage : ContentPage
		{
			public ListViewContentPage()
			{
				var itemSourceList = new List<CustomViewCell>();
				itemSourceList.Add(new CustomViewCell());
				itemSourceList.Add(new CustomViewCell());
				var listView = new ListView();
				listView.ItemTemplate = new DataTemplate(typeof(CustomViewCell));
				listView.ItemsSource = itemSourceList;
				listView.SeparatorVisibility = SeparatorVisibility.None;
				Content = listView;
			}
		}
		public class App : Application
		{
			public App()
			{
				// The root page of your application
				MainPage = new NavigationPage(new ListViewContentPage());
			}
		}
	}
