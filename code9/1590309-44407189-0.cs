    <ListView Grid.Row="3" Grid.ColumnSpan="2" Grid.Column="0" x:Name="KeySkillsList">
                    <ListView.ItemTemplate>
                        <DataTemplate>
                            <Grid>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto"></RowDefinition>
                                </Grid.RowDefinitions>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="Auto"></ColumnDefinition>
                                    <ColumnDefinition Width="Auto"></ColumnDefinition>
                                </Grid.ColumnDefinitions>
                                
                                <Label Grid.Row="0" Grid.Column="0"  Text="{Binding Name, Mode=TwoWay}"></Label>
                                <Switch Grid.Row="0" Grid.Column="1" IsToggled="{Binding Value, Mode=TwoWay}"></Switch>
                            </Grid>
                        </DataTemplate>
                    </ListView.ItemTemplate>
                </ListView>
