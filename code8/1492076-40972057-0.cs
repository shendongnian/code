    You can use this type
    
    
      <ListView x:Name="lstView"
                                  BackgroundColor="White"
                                  HasUnevenRows="True">
                            <ListView.ItemTemplate>
                                <DataTemplate>
                                    <ViewCell>
                                        <Grid Padding="0,10,0,15">
    
    
    
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition Width="10" />
                                                <ColumnDefinition Width="100" />
                                                <ColumnDefinition Width="*" />
                                                <ColumnDefinition Width="Auto" />
                                                <ColumnDefinition Width="10" />
                                            </Grid.ColumnDefinitions>
    
                                            <Grid.RowDefinitions>
                                                <RowDefinition Height="Auto" />
                                                <RowDefinition Height="Auto" />
                                            </Grid.RowDefinitions>
    
    
                                            <Image Grid.Column="1" Source="{Binding Image}" />
                                            <StackLayout Grid.Column="2" Orientation="Vertical">
                                                <Label Text="{Binding Title}" TextColor="#f36e22" />
                                                <Label Text="{Binding Text}" TextColor="Black" />
                                            </StackLayout>
    
                                            <Image Grid.Column="3" Source="{Binding smallImage}" />
    
                                        </Grid>
                                    </ViewCell>
                                </DataTemplate>
                            </ListView.ItemTemplate>
                        </ListView>
