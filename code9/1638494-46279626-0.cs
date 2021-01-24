    <Button Content="Click me!" Click="Button_Click_1" Margin="10" />
----------
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        button.Effect = new System.Windows.Media.Effects.DropShadowEffect()
        {
            BlurRadius = 10,
            ShadowDepth = 5
        };
    }
