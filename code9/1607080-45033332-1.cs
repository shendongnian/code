    <TextBox 
        Text="{Binding Tags,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"/>
    <CheckBox 
        Content="Untagged" 
        IsChecked="{Binding Untagged, Mode=TwoWay}" 
        IsEnabled="{Binding UntaggedEnabled, Mode=OneWay}"/>
