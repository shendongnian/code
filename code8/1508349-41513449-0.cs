    <ComboBox ItemsSource="{Binding MyItems}"
              SelectedItem="{Binding SelectedItem, Mode=TwoWay}">
        <i:Interaction.Triggers>
            <i:EventTrigger EventName="SelectionChanged">
                <i:InvokeCommandAction Command="{Binding SelectionChangedCommand}" />
            </i:EventTrigger>
        </i:Interaction.Triggers>
    </ComboBox>
