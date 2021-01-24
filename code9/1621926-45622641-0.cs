    <ListView x:Name="lvUsers">
        <ListView.View>
            <GridView>
                <GridViewColumn Header="Name" Width="120" DisplayMemberBinding="{Binding Path=Name}" />
                <GridViewColumn Header="Comment" Width="150" DisplayMemberBinding="{Binding Path=Comment}" />
                <GridViewColumn Header="Button">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Margin="6,2,6,2">
                                <Button Content="Click" Click="Button_Click" />
                            </StackPanel>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
