    <Grid>
    <Grid.Resources>
        <conv:LabelVisibilityConverter x:Key="LabelConverter"/>
    </Grid.Resources>
    <Grid.RowDefinitions>
        <RowDefinition></RowDefinition>
        <RowDefinition></RowDefinition>
    </Grid.RowDefinitions>
    <StackPanel>
        <RadioButton x:Name="1" Content="1"></RadioButton>
        <RadioButton x:Name="2" Content="2"></RadioButton>
        <RadioButton x:Name="3" Content="3"></RadioButton>
        <RadioButton x:Name="4" Content="4"></RadioButton>
        <RadioButton x:Name="5" Content="5"></RadioButton>    
    </StackPanel>
    <StackPanel Grid.Row="1">
        <Label Content="1">
            <Label.Visibility>
                <MultiBinding Converter="{StaticResource LabelConverter}">
                    <Binding Path="IsChecked" ElementName="1"/>
                    <Binding Path="IsChecked" ElementName="3"/>
                    <Binding Path="IsChecked" ElementName="5"/>
                </MultiBinding>
            </Label.Visibility>
        </Label>
        <Label Content="2">
            <Label.Visibility>
                <MultiBinding Converter="{StaticResource LabelConverter}">
                    <Binding Path="IsChecked" ElementName="2"/>
                    <Binding Path="IsChecked" ElementName="4"/>
                </MultiBinding>
            </Label.Visibility>         
        </Label>
    </StackPanel>
    </Grid>
