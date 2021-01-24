    <DataGridTextColumn.EditingElementStyle>
        <Style TargetType="{x:Type TextBox}">
            <EventSetter Event="TextChanged" Handler="tbx_ConcernEnter_TextChanged"/>
            <EventSetter Event="Loaded" Handler="TextBox_Loaded" />
        </Style>
    </DataGridTextColumn.EditingElementStyle>
----------
    private void TextBox_Loaded(object sender, RoutedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        DataObject.AddPastingHandler(textBox, OnPaste);
    }
    private void OnPaste(object sender, DataObjectPastingEventArgs e)
    {
        //paste detected...
    }
