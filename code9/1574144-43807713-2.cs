    <ComboBox SelectedValuePath="Content"
              SelectedValue="{Binding Source={x:Static properties:Settings.Default},
                                      Path=KeyModifier, Mode=TwoWay}">
        <ComboBoxItem>Alt</ComboBoxItem>
        <ComboBoxItem>Shift</ComboBoxItem>
        <ComboBoxItem>Ctrl</ComboBoxItem>
        <ComboBoxItem>Win</ComboBoxItem>
    </ComboBox>
