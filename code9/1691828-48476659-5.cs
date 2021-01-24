    <ComboBox ...
              ItemsSource="{Binding Points}"
              SelectedItem="{Binding PointsSelectedItem}">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Point}"/>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
