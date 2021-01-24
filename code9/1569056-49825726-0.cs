        <ContentPage.Content>
    
            <StackLayout>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto" />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="30*" />
                        <ColumnDefinition Width="30*" />
                        <ColumnDefinition Width="30*" />
                    </Grid.ColumnDefinitions>
                    <Label  Grid.Column="0" Grid.Row="0" Text="ID"/>
                    <Label  Grid.Column="1" Grid.Row="0" Text="USERS"/>
                    <Label Grid.Column="2" Grid.Row="0" Text="PASSWORD"/>
    
                </Grid>
            
            
            <ListView x:Name="listx">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <Grid>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto" />
                                </Grid.RowDefinitions>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="30*" />
                                    <ColumnDefinition Width="30*" />
                                    <ColumnDefinition Width="30*" />
                                </Grid.ColumnDefinitions>
    
                                <Label  Grid.Column="0" Text="{Binding id}"/>
                                <Label  Grid.Column="1" Text="{Binding usr}"/>
                                <Label Grid.Column="2" Text="{Binding pass}"/>
                            </Grid>
                            
                            
    
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
                
            </ListView>
            </StackLayout>
    
        </ContentPage.Content>
    </ContentPage>
