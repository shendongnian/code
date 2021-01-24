    <ItemsControl Grid.ColumnSpan="3" Grid.Row="1" HorizontalAlignment="Center"
                  ItemsSource="{Binding MyItems}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.Resources>
                        <CollectionViewSource x:Key="cvs" Source="{Binding CBSource}" />
                    </Grid.Resources>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="200"/>
                        <ColumnDefinition Width="200"/>
                        <ColumnDefinition Width="200"/>
                    </Grid.ColumnDefinitions>
                    <Label HorizontalContentAlignment="Center" Grid.Column="0" Content="TEST"/>
                    <Label HorizontalContentAlignment="Center" Grid.Column="1" Content="{Binding SecondProperty}"/>
                    <Label HorizontalContentAlignment="Center" Grid.Column="2" Content="{Binding ThirdProperty}"/>
                <ComboBox HorizontalAlignment="Center" Grid.Column="2" Width="140" Visibility="{Binding HasCombobox, Converter={StaticResource BoolToVis}}">
                        <ComboBox.ItemsSource>
                            <CompositeCollection>
                                <CollectionContainer Collection="{Binding Source={StaticResource cvs}}" />
                                <ComboBoxItem>
                                    <Button Content="INeedAButtonHere"></Button>
                                </ComboBoxItem>
                            </CompositeCollection>
                        </ComboBox.ItemsSource>
                    </ComboBox>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
