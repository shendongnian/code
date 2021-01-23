       private void btnreturn_Click(object sender, RoutedEventArgs e)
    {
        int gettext;
        int.TryParse(txtcount.Text, out gettext);
     Color Colorpicker; 
            //this is where i am getting my error and i need to 
           //check to see if the selected colour is not null before taking it's value
        if(colorpicker.SelectedColor != null){
            Colorpicker = (Color)colorpicker.SelectedColor;
        MainWindow win2 = new MainWindow(gettext, Colorpicker);
        win2.Show();
        Close();
        } else {
             //do something else
        }
    }
