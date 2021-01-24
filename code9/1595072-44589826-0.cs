    <ListView ItemsSource="{Binding Servers}" Margin="8,30,10,68">
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.View>
            <GridView>
                <GridViewColumn Width="90" Header="Select For Sync">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <CheckBox Tag="{Binding ID}" IsChecked="{Binding IsSelected}"></CheckBox>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn Width="280" Header="Pad Name"  DisplayMemberBinding="{Binding NodeName}" />
            </GridView>
        </ListView.View>
    </ListView>
