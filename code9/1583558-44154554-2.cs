    <Button x:Name="button" Content="Button" Click="clicked" MouseLeave="mouseleaved"/>
    <Popup Name="popup" PlacementTarget="{Binding ElementName=button}" StaysOpen="True" MouseLeave="mouseleaved">
        <Border Background="Yellow">
            <TextBlock>contents...</TextBlock>
        </Border>
    </Popup>
----------
    private void clicked(object sender, RoutedEventArgs e)
    {
        popup.IsOpen = true;
    }
    private void mouseleaved(object sender, MouseEventArgs e)
    {
        if (!button.IsMouseOver && !popup.IsMouseOver)
            popup.IsOpen = false;
    }
