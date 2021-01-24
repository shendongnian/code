    <Grid DataContext="{StaticResource ViewModel}">
        <ComboBox ItemsSource="{Binding Departments}" 
                SelectedItem="{Binding Employee.Department}"
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding Name}" />
                    </StackPanel>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
    </Grid>
