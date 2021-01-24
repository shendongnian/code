    <UserControl x:Class="MainMenu.Views.Test" ...
                 DataContext="{Binding MyTestViewModel, Source={StaticResource Locator}}">
        <Grid>
            ...
    
            <local:UsersGrid x:Name="oUsers" Grid.Column="0" />
        
            <DockPanel Grid.Column="1" >
                <StackPanel>
                    <TextBox Text="{Binding SelectedUser.Name}" />
                </StackPanel>
            </DockPanel>
        </Grid>
    </UserControl>
    
    <!-- Note that DataContext is NOT set here. Because it is not set,
    <!--- it will use DataContext from parent item, which is TestViewModel -->
    <UserControl x:Class="MainMenu.Views.UsersGrid" ...>
        ...
    
        <telerik:RadGridView x:Name="grid_users"
                        ItemsSource="{Binding Users}"
                        SelectedItem="{Binding SelectedUser}"
                        ...>
        ...
    </UserControl>
