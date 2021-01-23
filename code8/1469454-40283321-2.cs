    <Button x:Name="hideBtn"
            Grid.Row="0"
            Width="50"
            Height="50"
            Margin="0,0,5,0"
            HorizontalAlignment="Right"
            VerticalAlignment="Bottom"
            Click="hideBtn_Click"
            Visibility="{Binding Tag, ElementName=photo1, Mode=TwoWay}">
        <Button.Background>
            <ImageBrush ImageSource="images/media/ikon-56-app-white-down.png" Stretch="Uniform" />
        </Button.Background>
    </Button>
-
    private void hideBtn_Click(object sender, RoutedEventArgs e)
    {
        ChangeButtonVisibility(sender);
    }
    
    private void ChangeButtonVisibility(object sender)
    {
        var visibility = (sender as Button)?.Visibility;
        if (visibility.Equals(Visibility.Visible))
        {
            (sender as Button).Visibility = Visibility.Collapsed;
        }
        else
        {
            (sender as Button).Visibility = Visibility.Visible;
        }
    }
