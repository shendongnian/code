    <Window.Resources>
        <local:VisibilityToBoolConverter x:Key="VisibilityToBoolConverter"/>
    </Window.Resources>
    <ListBox DataContext="{Binding}" ItemsSource="{Binding Persons}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <TextBox Text="{Binding Name}" />
                    <RadioButton Content="Is sentenced to death" IsChecked="{Binding IsSentenced}" />
                    <DockPanel  Visibility="{Binding IsSentenced , Converter={StaticResource VisibilityToBoolConverter}}">
                        <Label Content="Sentence:  "/>
                        <TextBlock Text="{Binding Sentence}" />
                    </DockPanel>
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate> 
    </ListBox>
