    private void icName_MouseDown(object sender, MouseButtonEventArgs e)
    {
        ContentPresenter cp = e.OriginalSource as ContentPresenter;
        if (cp != null && VisualTreeHelper.GetChildrenCount(cp) > 0)
        {
            Button button = VisualTreeHelper.GetChild(cp, 0) as Button;
            //do whatever you want with the Button here...
            if (button != null && button.Tag != null)
                MessageBox.Show(button.Tag.ToString());
        }
    }
----------
    <ItemsControl x:Name="icName" MouseDown="icName_MouseDown" >
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Button x:Name="btnName" Content="Button" IsEnabled="False" Tag="{Binding ItemName}"></Button>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
