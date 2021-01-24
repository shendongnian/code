    <Grid>
        <Button Content="Toggle" Click="toggle_click"></Button>
    </Grid>
    <DockPanel LastChildFill="False">
        <ListView x:Name="lv1">
            <TextBlock>1</TextBlock>
        </ListView>
        <ListView x:Name="lv2" Visibility="Collapsed">
            <TextBlock>2</TextBlock>
        </ListView>
    </DockPanel>
----------
    private void toggle_click(object sender, RoutedEventArgs e)
    {
        lv1.Visibility = lv1.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        lv2.Visibility = lv1.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
    }
