    <ItemsControl ItemsSource="{Binding Path=MyLabelList}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Label Content="{Binding content}" Grid.Column="{Binding columnNr}" Grid.Row="{Binding rowNr}" Style="{StaticResource MyLabel}" />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
