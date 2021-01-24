    <Grid>
        <TreeView ItemsSource="{Binding Collection}">
            <TreeView.Resources>
                <HierarchicalDataTemplate DataType="{x:Type local:Work}" ItemsSource="{Binding WorkItems}">
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Name}"/>
                        <Button Content="+" >
                            <Button.Style>
                                <Style TargetType="Button">
                                    <Setter Property="Margin" Value="5,2,5,2"/>
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding IsFinalItem}" Value="False">
                                            <Setter Property="Visibility" Value="Collapsed"/>
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </Button.Style>
                        </Button>
                    </StackPanel>
                </HierarchicalDataTemplate>
            </TreeView.Resources>
        </TreeView>
    </Grid>
