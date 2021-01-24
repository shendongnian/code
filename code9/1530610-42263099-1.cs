    <TreeView DataContext="{Binding}" ItemsSource="{Binding Models}">
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Models}">
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="13"/>
                        <ColumnDefinition Width="13"/>
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="20" />
                    </Grid.RowDefinitions>
                    <TextBlock Text="{Binding Name}" Grid.Column="0" Tag="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=TreeView}}">
                        <TextBlock.ContextMenu>
                            <ContextMenu Tag="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                                <MenuItem Header="Delete Document" ToolTip="{Binding Name}" 
                                                  Command="{Binding PlacementTarget.Tag.DataContext.PCommand, 
                                                            RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}"    
                                                  CommandParameter="{Binding Name}" />
                            </ContextMenu>
                        </TextBlock.ContextMenu>
                    </TextBlock>
                </Grid>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
     </TreeView>
