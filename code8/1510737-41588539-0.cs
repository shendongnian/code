      <DataGrid
            x:Name="myGrid"
            AutoGenerateColumns="False"
            CanUserAddRows="False"
            HorizontalScrollBarVisibility="Visible"
            ItemsSource="{Binding Persons}">
            <DataGrid.Resources>
                <local:GridToIndexConverter x:Key="GridToIndexConverter" />
                <ContextMenu x:Key="DataGridColumnHeaderContextMenu">
                    <MenuItem
                        Command="{Binding DataContext.FreezColumnCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}"
                        CommandParameter="{Binding PlacementTarget.DisplayIndex, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}"
                        Header="Freez Column" />
                </ContextMenu>
                <Style TargetType="{x:Type DataGridColumnHeader}">
                    <Setter Property="ContextMenu" Value="{StaticResource DataGridColumnHeaderContextMenu}" />
                </Style>
            </DataGrid.Resources>
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Story}" Header="Story" />
                <DataGridCheckBoxColumn Binding="{Binding Design}" Header="Design" />
                <DataGridTextColumn Binding="{Binding CadId}" Header="CadId" />
            </DataGrid.Columns>
        </DataGrid>
