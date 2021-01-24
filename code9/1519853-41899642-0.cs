    <GridViewColumn Header="Selected">
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <CheckBox x:Name="chk" IsChecked="{Binding MyListItemsBoolField}" />
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
