    <StackPanel>
        <ListView ItemsSource="{Binding Values}" SelectedItem="{Binding SelectedValue}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Path=Item1}" />
                        <TextBlock Text="=" />
                        <TextBlock Text="{Binding Path=Item2}" />
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
        <StackPanel Orientation="Horizontal">
            <TextBox Text="Selected:" Background="DarkGray" />
            <TextBox Text="{Binding SelectedValue.Item1, Mode=OneWay}" Background="DarkGray" />
        </StackPanel>
    </StackPanel>
