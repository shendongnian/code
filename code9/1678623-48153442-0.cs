    <ComboBox.ItemContainerStyle>
        <Style TargetType="ComboBoxItem">
            <Setter Property="IsEnabled" Value="{Binding DataContext.ComboBoxItemIsEnabled, RelativeSource={RelativeSource AncestorType=ComboBox}}" />
         </Style>
    </ComboBox.ItemContainerStyle>
