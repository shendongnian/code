                    <ListBox>
                        <ListBox.ItemTemplateSelector>
                            <selector:MyTemplateSelector>
                                <selector:MyTemplateSelector.StringTemplate>
                                    <DataTemplate>
                                        <Grid>
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition Width="100"/>
                                                <ColumnDefinition Width="200"/>
                                            </Grid.ColumnDefinitions>
                                            <TextBlock Text="{Binding Name}" Margin="2" Grid.Column="0"/>
                                            <TextBox Text="{Binding Value, Mode=TwoWay}" Margin="2" Grid.Column="1" IsEnabled="{Binding IsLocked}"/>
                                        </Grid>
                                    </DataTemplate>
                                </selector:MyTemplateSelector.StringTemplate>
                                <selector:MyTemplateSelector.BooleanTemplate>
                                    <DataTemplate>
                                        <Grid>
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition Width="100"/>
                                                <ColumnDefinition Width="200"/>
                                            </Grid.ColumnDefinitions>
                                            <TextBlock Text="{Binding Name}" Margin="2" Grid.Column="0"/>
                                            <ToggleButton IsChecked="{Binding Value, Mode=TwoWay}" Margin="2" Grid.Column="1" IsEnabled="{Binding IsLocked}"/>
                                        </Grid>
                                    </DataTemplate>
                                </selector:MyTemplateSelector.BooleanTemplate>
                            </selector:MyTemplateSelector>
                        </ListBox.ItemTemplateSelector>
                    </ListBox>
