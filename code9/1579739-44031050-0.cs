    //Window 1
    private void btnShowWindow2_Click(object sender, RoutedEventArgs e)
    {
        var form = new Window2("My Art", 100);
        form.Show();
    }
    
    //Window 2 Constructor
    public Window2(string ArtName, int Price)
    {
         MessageBox.Show("ArtName: " + ArtName + "\nPrice: " Price.ToString() + " dollars");
    }
