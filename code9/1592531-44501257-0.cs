    <ComboBox x:Name="selector">
        <ComboBox.ItemsSource>
            <CompositeCollection>
                <CollectionContainer x:Name="cc" />
                <ComboBoxItem IsEnabled="False" Content="---" />
                <ComboBoxItem FontStyle="Italic" Content="Add New" Selected="New_Selected" />
            </CompositeCollection>
        </ComboBox.ItemsSource>
    </ComboBox>
