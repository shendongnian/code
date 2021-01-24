    <ItemsControl ItemsSource="{Binding DynamicControlObjects}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBox Text="{Binding Text}"
                         ToolTip="{Binding Tooltip}"
                         IsEnabled="{Binding IsEnabled}"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
