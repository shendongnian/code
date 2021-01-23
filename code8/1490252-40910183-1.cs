     <ListView Name="lst1" ItemsSource="{Binding Fields}">
        <ListView.View>
            <GridView>
                <GridView.Columns>
                    <GridViewColumn>
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <CheckBox  IsChecked="{Binding FieldVis}" Name="chbVis"/>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                        <GridViewColumn.Header>
                            <TextBlock Text="Visibility"></TextBlock>
                        </GridViewColumn.Header>
                    </GridViewColumn>
                    <GridViewColumn>
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <TextBox Text="{Binding Path=Name}"/>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                        <GridViewColumn.Header>
                            <TextBlock Text="Field" Visibility="{Binding fieldVis, Converter={StaticResource BoolToVis}}"></TextBlock>
                        </GridViewColumn.Header>
                    </GridViewColumn>
                 </GridView.Columns>
            </GridView>
        </ListView.View>
    </ListView>
