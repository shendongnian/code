    <ItemsControl.ItemTemplate>
        <DataTemplate>
            <StackPanel>
                <Button Style="{StaticResource mainButton}"
                                    Command="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ItemsControl}}, Path=DataContext.PlaySound}" 
                                    CommandParameter="{Binding Path=Name}"
                                    Tag="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ItemsControl}}}">
                    <TextBlock Text="{Binding Path=NormalizedName}" TextWrapping="Wrap" Height="auto" />
                    <Button.ContextMenu>
                        <ContextMenu>
                            <MenuItem Header="{Binding Path=Name}" 
                                      Command="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ContextMenu}}, Path=PlacementTarget.Tag.DataContext.RemoveSound}" 
                                      CommandParameter="{Binding Path=Name}">
                                <MenuItem.Icon>
                                    <Image Source="\WpfPractice;component\Images\CoffeeArt.png" Width="20" VerticalAlignment="Center"/>
                                </MenuItem.Icon>
                            </MenuItem>
                        </ContextMenu>
                    </Button.ContextMenu>
                </Button>
            </StackPanel>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
