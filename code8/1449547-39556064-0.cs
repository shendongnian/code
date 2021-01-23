    <TreeView Name="treeView" Grid.IsSharedSizeScope="True" TreeViewItem.Expanded="TreeViewItem_Expanded" AutomationProperties.IsColumnHeader="True" AutomationProperties.IsRowHeader="True" AllowDrop="True" VirtualizingStackPanel.IsVirtualizing="True" VirtualizingStackPanel.VirtualizationMode="Recycling">
      <TreeViewItem>
        <TreeViewItem.Header>
          <Grid>
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="*" SharedSizeGroup="A" />
              <ColumnDefinition Width="auto" SharedSizeGroup="B"  />
            </Grid.ColumnDefinitions>
            <Label>2.3.00</Label>
            <Label Grid.Column="2">Something</Label>
          </Grid>
        </TreeViewItem.Header>
      </TreeViewItem>
      <TreeViewItem>
        <TreeViewItem.Header>
          <Grid>
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="*" SharedSizeGroup="A"  />
              <ColumnDefinition Width="auto" SharedSizeGroup="B"  />
            </Grid.ColumnDefinitions>
            <Label>22.03.2000</Label>
            <Label Grid.Column="2">Something 2</Label>
          </Grid>
        </TreeViewItem.Header>
      </TreeViewItem>
    </TreeView>
