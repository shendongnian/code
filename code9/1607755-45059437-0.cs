    <DataGridComboBoxColumn.ElementStyle>
        <Style TargetType="ComboBox">
            <Setter Property="ItemsSource" Value="{Binding TestList}"/>
            <EventSetter Event="Loaded" Handler="OnLoaded" />
        </Style>
    </DataGridComboBoxColumn.ElementStyle>
----------
    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        ComboBox cmb = sender as ComboBox;
        dynamic dataObject = cmb.DataContext;
        cmb.SelectedValue = dataObject.DbId;
    }
