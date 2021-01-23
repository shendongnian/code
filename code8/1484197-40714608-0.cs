    <DataGrid x:Name="DataGridOrderItems" ... SelectionMode="Extended" SelectionUnit="FullRow" ...>
        <DataGrid.Columns>
            <DataGridTextColumn Header="Resource Id" Binding="{Binding ResourceId}" IsReadOnly="True"/>
            <DataGridTextColumn Header="Resource Name" Binding="{Binding DisplayTitle}" IsReadOnly="True"/>
            <DataGridTextColumn Header="Quantity" Binding="{Binding Quantity}" />
            <DataGridTextColumn Header="Type" Binding="{Binding ResourceType}" IsReadOnly="True"/>
            <DataGridTextColumn Header="Order Date" Binding="{Binding OrderDate, StringFormat=\{0:d\}}" IsReadOnly="True" />
            <DataGridTextColumn Header="Status" Binding="{Binding Status}" IsReadOnly="True"/>
        </DataGrid.Columns>
        <DataGrid.ContextMenu>
            <ContextMenu >
                <MenuItem Header="Select All" Click="SelectAllDatagridOrderItems"  />
            </ContextMenu>
        </DataGrid.ContextMenu>
        <DataGrid.RowHeaderTemplate>
            <DataTemplate>
                <CheckBox IsChecked="{Binding Path=IsSelected, Mode=TwoWay, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGridRow}}}"/>
            </DataTemplate>
        </DataGrid.RowHeaderTemplate>
    </DataGrid>
