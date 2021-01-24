        <Button x:Name="TheButton" PreviewMouseDown="Button_PreviewMouseDown">YOOOO</Button>
       private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TheButton.BorderThickness = new Thickness(5, 5, 5, 5);
        }
