    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <StackPanel>
            <CheckBox Name="X" Content="X"/>
            <Grid Background="Red" Name="A" IsEnabled="{Binding IsChecked, ElementName=X}">
                <TextBlock/>
            </Grid>
        </StackPanel>
        <StackPanel Grid.Column="1">
            <CheckBox Name="Y" Content="Y"/>
            <Grid Background="Blue" Name="B" IsEnabled="{Binding IsChecked, ElementName=Y}">
                <TextBlock/>
            </Grid>
        </StackPanel>
    </Grid>
