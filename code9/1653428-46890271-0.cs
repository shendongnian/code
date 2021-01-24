    <TreeView Grid.Row="0" x:Name="TreeViewLocalSystem"  BorderBrush="Transparent" Panel.ZIndex="0">
        <TreeView.ItemContainerStyle>
            <Style TargetType="TreeViewItem">
                <EventSetter Event="PreviewMouseLeftButtonDown" Handler="TreeViewLocalSystem_PreviewMouseLeftButtonDown" />
                <Setter Property="IsExpanded" Value="{Binding IsExpanded, Mode=TwoWay}" />
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
                <Style.Triggers>
                    <Trigger Property="IsSelected" Value="True">
                        <Setter Property="Background" Value="{StaticResource TextBoxBackgroundColor}"></Setter>
                    </Trigger>
                    <Trigger Property="IsSelected" Value="False">
                        <Setter Property="Background" Value="Transparent"></Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </TreeView.ItemContainerStyle>
        <TreeView.Resources>
            <HierarchicalDataTemplate ItemsSource="{Binding Path=Children}" DataType="{x:Type local:LocalTreeViewItemModel}">
                <TextBlock Text="{Binding Path=Text}" HorizontalAlignment="Left" FontSize="{StaticResource MediumFontSize}" />
            </HierarchicalDataTemplate>
        </TreeView.Resources>
    </TreeView>
----------
    private void TreeViewLocalSystem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        //...
    }
