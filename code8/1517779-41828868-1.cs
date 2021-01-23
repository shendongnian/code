           <ListView BorderThickness="2" BorderBrush="Red">
                <ListView.View>
                    <GridView >
                        <GridViewColumn Header="First Name">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="Bob"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="LastName">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <TextBlock Text="Bobson" HorizontalAlignment="Right"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView>
                </ListView.View>
                <ListView.ItemsSource>
                    <sys:String>Test</sys:String>
                </ListView.ItemsSource>
            </ListView>
