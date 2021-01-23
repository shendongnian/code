    <Grid DataContext="{Binding YourViewModel}">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="0.2*" />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
    
            <StackPanel>
    
                <Label Style="{StaticResource menu}" Content="Tours" />
                <ListView Name="lvTours" ItemsSource="{Binding Tours}" >
                    <ItemsControl.ItemTemplate>
    
                        <DataTemplate>
                            <Label Content="{Binding Nom}" />
                        </DataTemplate>
    
                    </ItemsControl.ItemTemplate>
                </ListView>
    
                <Label Style="{StaticResource menu}" Content="Parties" />
                <ListView Name="lvParties" ItemsSource="{Binding ElementName=lvTours, Path=SelectedItem.Parties}" >
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <Label Content="{Binding Nom}" />
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ListView>
    
                <Label Style="{StaticResource menu}" Content="Équipes" />
                <ListView Name="lvEquipes"  ItemsSource="{Binding ElementName=lvParties, Path=SelectedItem.Equipes}" >
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <Label Content="{Binding Nom}" />
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ListView>
            </StackPanel>
    
            <Label Content="Here's the content..." Grid.Column="1" Margin="30" />
    
        </Grid>
