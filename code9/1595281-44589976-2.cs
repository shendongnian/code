       ListView listview = new ListView()
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				SeparatorVisibility = SeparatorVisibility.None,
				RowHeight = 30,
			};
	listview.ItemTemplate = new DataTemplate(typeof(cell));
	listview.ItemSelected += listviewItemSelected;
