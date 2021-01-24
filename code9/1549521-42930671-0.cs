    <Grid>
       <TreeView ItemsSource="{Binding Scenes}" x:Name="rootView">
           <TreeView.Resources>
                <ContextMenu x:Key="SceneLevel" DataContext="{Binding RelativeSource={RelativeSource Self}, Path=PlacementTarget.Tag}">
                    <MenuItem Header="Add selected character" Command="{Binding AddSelectedCharacter}"/>
                </ContextMenu>
                <ContextMenu x:Key="CharacterLevel">
                    <MenuItem Header="Character Level"/>
                </ContextMenu>
            </TreeView.Resources>
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding Characters}">
                    <StackPanel Orientation="Horizontal" ContextMenu="{StaticResource SceneLevel}" Tag="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type TreeView}}, Path=DataContext}">
                        <TextBlock Text="{Binding Name}"></TextBlock>
                    </StackPanel>
                    <HierarchicalDataTemplate.ItemTemplate>
                        <DataTemplate>
                            <Border BorderThickness="2" BorderBrush="LightBlue" HorizontalAlignment="Center" VerticalAlignment="Center" Margin="2" CornerRadius="5,5,5,5">
                                <StackPanel Orientation="Horizontal" Margin="3" ContextMenu="{StaticResource CharacterLevel}">
                                    <TextBlock FontFamily="Levenim MT" FontSize="16" VerticalAlignment="Center" MinWidth="50" Text="{Binding Name}"></TextBlock>
                                </StackPanel>
                            </Border>
                        </DataTemplate>
                    </HierarchicalDataTemplate.ItemTemplate>
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
    
        </TreeView>
    </Grid>
