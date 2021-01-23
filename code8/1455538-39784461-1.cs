    <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <local:TreeViewA ItemsSource="{Binding Documents}" SelectedItem="{Binding SelectedDocument, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}">
                <TreeView.ItemTemplate>
                    <DataTemplate>
                        <WrapPanel>
                            <Image Source="whereever" Width="40" Height="40"/>
                            <TextBlock Text="{Binding Name}"/>
                        </WrapPanel>
                    </DataTemplate>
                </TreeView.ItemTemplate>
            </local:TreeViewA>
    
            <DataGrid Grid.Column="1" ItemsSource="{Binding SubDocuments, UpdateSourceTrigger=PropertyChanged, Mode=OneWay}" AutoGenerateColumns="False">
                <DataGrid.Columns>
    
                    <DataGridTextColumn Header="Document Type Name" Binding="{Binding DocumentTypeName}" IsReadOnly="True"></DataGridTextColumn>
                    <DataGridTextColumn Header="Status" Binding="{Binding Name}" IsReadOnly="True"></DataGridTextColumn>
                    <DataGridTextColumn Header="Description" Binding="{Binding Description}" IsReadOnly="True"></DataGridTextColumn>
    
                    <DataGridTextColumn Header="Type" Binding="{Binding Type}" IsReadOnly="True"></DataGridTextColumn>
    
                </DataGrid.Columns>
    
            </DataGrid>
        </Grid>
