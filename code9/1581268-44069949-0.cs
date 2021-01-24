    <ComboBox x:Name="FontAligmentCombo">
        <ComboBox.Resources>
            <Style TargetType="Button">
                <EventSetter Event="Click" Handler="OnClick" />
            </Style>
        </ComboBox.Resources>
        <ComboBoxItem IsSelected="True">
            <Button Command="EditingCommands.AlignLeft" ToolTip="Align Left">
                <Viewbox>
                    <ContentPresenter Content="{DynamicResource icon8_Win10_AlignLeft}" />
                </Viewbox>
            </Button>
        </ComboBoxItem>
        <ComboBoxItem>
            <Button Command="EditingCommands.AlignCenter" ToolTip="Align Center">
                <Viewbox>
                    <ContentPresenter Content="{DynamicResource icon8_Win10_AlignCenter}" />
                </Viewbox>
            </Button>
        </ComboBoxItem>
    </ComboBox>
----------
    private void OnClick(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        ComboBoxItem cbi = FindParent<ComboBoxItem>(button);
        if (cbi != null)
        {
            FontAligmentCombo.SelectedItem = cbi;
            FontAligmentCombo.IsDropDownOpen = false;
        }
    }
