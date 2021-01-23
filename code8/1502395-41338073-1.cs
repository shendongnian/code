    <ListView Grid.Row="2" HorizontalAlignment="Stretch" Name="MyListView"
    Margin="5" SelectionChanged="SelectedSongChanged" Grid.RowSpan="2">
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="Favourite">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <CheckBox Margin="5, 0" IsChecked="{Binding Favourite}"/>
                                    <!-- Your control type and value goes here. Bind the value
                                         to the name of the method that represents this value
                                         in your .cs file. In my case, this was 'Favourite' -->
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Play">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <CheckBox Margin="5, 0" IsChecked="{Binding Play}"/>
                                    <!-- Repeat this for every control you need in your
                                         ListView's rows -->
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Name">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Margin="5, 0" Text="{Binding Name}"/>
                                    <!-- You can add non-binded values too to each column.
                                         These values will simply be added to every row
                                         and be the same. -->
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView>
                </ListView.View>
            </ListView>
