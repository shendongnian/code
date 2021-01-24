    //Window1
    private void btnShowWindow2_Click(object sender, RoutedEventArgs e)
    {
    	var form = new Window2()
    	{
    		Price = 200,
    		ArtName = "My Art"
    	};
    	form.Show();
    }
    
    //Window2
    
    publuc string ArtName {get; set;}
    publuc string Price {get; set;}
    
    private void Window2_Loaded(object sender, RoutedEventArgs e)
    {
    	 MessageBox.Show("ArtName: " + ArtName + "\nPrice: " Price.ToString() + " dollars");
    }
