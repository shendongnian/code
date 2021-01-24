			var label = new Label { Text = "TRIP #5", FontSize = 16, TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Start, Margin = new Thickness(0, 0, 0, 10) };
			var grid = new Grid {
				RowDefinitions =
				{
					new RowDefinition { Height = new GridLength(3, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(2, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(2, GridUnitType.Star) }
				},
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) },    
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
				},
				Children =
				{
					label,
				}
			};
			grid.Padding = new Thickness(0,20,0,0);
			Grid.SetRow(label, 0);
			Grid.SetColumn(label, 0);
			Grid.SetColumnSpan(label,2);
			Grid.SetRowSpan(label, 3);
			    
			this.Content = grid;
