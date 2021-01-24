    <ListView ItemsSource="{Binding Items}">
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="IsSelected" Value="{Binding IsSelected}"/>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.View>
            <GridView>
                <GridViewColumn>
                    <GridViewColumn.Header>
                        <CheckBox IsChecked="{Binding AllSelected}"/>
                    </GridViewColumn.Header>
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <CheckBox IsChecked="{Binding IsSelected}" />
                            </StackPanel>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn Header="Name" Width="120" DisplayMemberBinding="{Binding Name}" />
                <GridViewColumn Header="Age" Width="50" DisplayMemberBinding="{Binding Age}" />
                <GridViewColumn Header="Mail" Width="150" DisplayMemberBinding="{Binding Mail}" />
            </GridView>
        </ListView.View>
    </ListView>
