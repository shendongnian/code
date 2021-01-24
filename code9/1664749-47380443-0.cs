    private void Button_Clicked(object sender, RoutedEventArgs e) { 
        var button = sender as Button;
        if(button.Command != null){
            button.Command.Execute(null);
        }
    } 
