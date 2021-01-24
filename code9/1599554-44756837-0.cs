    <ComboBox ItemsSource="{Binding Elements}">
        <ComboBox.ItemContainerStyle>
            <Style TargetType="ComboBoxItem">
                <Setter Property="HorizontalContentAlignment" Value="Stretch" />
            </Style>
        </ComboBox.ItemContainerStyle>
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <CheckBox IsChecked="{Binding IsSelected, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                          Content="{Binding Caption}"/>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
