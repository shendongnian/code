    bool toggle=false;
    //Code for toggling your app bar visibility 
    private void UserControl_RightTapped(object sender, RoutedEventArgs e)
    {   
        if(toggle)
        {
           appBarName.Visibility = Visibility.Visible; 
           toggle=false;
        }else{
           appBarName.Visibility = Visibility.Collapsed; 
           toggle=true;
        }
         
    }
