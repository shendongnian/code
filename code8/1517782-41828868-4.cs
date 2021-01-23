            <ListView BorderThickness="2" BorderBrush="Red" Style="{StaticResource CustomListViewStyle}">
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
                    <x:Array Type="{x:Type sys:String}">
                        <sys:String>1</sys:String>
                        <sys:String>1</sys:String>
                        <sys:String>1</sys:String>
                        <sys:String>1</sys:String>
                        <sys:String>1</sys:String>
                        <sys:String>1</sys:String>
                    </x:Array>
                </ListView.ItemsSource>
            </ListView>
