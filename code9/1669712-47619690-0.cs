    <HierarchicalDataTemplate x:Key="level2Template">
                    <Grid Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType=TreeView}}">
                        <Grid.ContextMenu>
                            <ContextMenu DataContext="{Binding PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                                <MenuItem Header="Delete" Command="{Binding DeleteCommand}"/>
                            </ContextMenu>
                        </Grid.ContextMenu>
                        <Grid.RowDefinitions>
                            <RowDefinition></RowDefinition>
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition></ColumnDefinition>
                            <ColumnDefinition></ColumnDefinition>
                        </Grid.ColumnDefinitions>
                        <TextBlock Grid.Column="0" Text="{Binding}">
                        </TextBlock>
                    </Grid>
                </HierarchicalDataTemplate>
