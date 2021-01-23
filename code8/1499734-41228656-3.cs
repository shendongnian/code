    <ItemsControl ItemsSource="{Binding VehicleCollection}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <CheckBox Content="{Binding Name}" IsChecked="{Binding IsVisible}"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
