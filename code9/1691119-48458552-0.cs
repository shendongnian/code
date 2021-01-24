    protected override void OnAppearing ()
    {
	   base.OnAppearing();
	   // Create cols for each img
	   for(int col = 0; col < Images.Length; ++col){
		   grid.ColumnDefinitions.Add(new ColumnDefinitions { Width = new GridLenght(1, GridUnitType.Star)});
	   }
	   // Populate grid
	   for(int col = 0; col < Images.Length; ++col){
		   grid.Children.Add(new Image { source = Images[col] },0,col);
	   }
    }
