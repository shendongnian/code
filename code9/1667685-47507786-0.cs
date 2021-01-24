    <TreeView Grid.Row="3" x:Name="TreeViewServer"  Panel.ZIndex="0">
        <TreeView.ItemContainerStyle>
            <Style TargetType="TreeViewItem" BasedOn="{StaticResource StyleTreeViewItemContainer}">
                <Style.Triggers>
                    <Trigger Property="IsSelected" Value="True">
                        <Setter Property="BorderBrush" Value="Green"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </TreeView.ItemContainerStyle>
        <TreeView.Resources>
            <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" Color="Transparent" />
            <HierarchicalDataTemplate ItemsSource="{Binding Path=Children}"   DataType="{x:Type ViewModels:ServerTreeViewItemModel}">
                <TreeViewItem  AllowDrop="{Binding AllowDrop}" Margin="{StaticResource MarginTreeViewItem}"    HorizontalContentAlignment="Left"  PreviewMouseDown="TreeViewItemServer_PreviewMouseDown" HorizontalAlignment="Left" FontSize="{StaticResource MediumFontSize}" Drop="TreeViewItem_Drop" >
                    <TreeViewItem.Header>
                        <Border BorderBrush="{Binding Background, RelativeSource={RelativeSource AncestorType=TreeViewItem}}"  BorderThickness="1">
                            <TextBlock Text="{Binding Path=Text}"></TextBlock>
                        </Border>
                    </TreeViewItem.Header>
                </TreeViewItem>
            </HierarchicalDataTemplate>
        </TreeView.Resources>
    </TreeView>
