     <StackPanel x:Name="root">
            <StackPanel.DataContext>
                <vm:MainWindowViewModel></vm:MainWindowViewModel>
            </StackPanel.DataContext>
            <Button Command="{Binding AddRoot}">Add</Button>
            <TreeView Height="400">
                <TreeView.Resources >
                    <Style TargetType="{x:Type TreeViewItem}">
                        <Setter Property="IsExpanded" Value="True">
                        </Setter>
                    </Style>
                    <vm:HierarchicalDataConverter x:Key="HierarchicalDataConverter"/>
                    <HierarchicalDataTemplate x:Key="ParentEntityTemplate" DataType="{x:Type vm:ParentEntity}" >
                        <HierarchicalDataTemplate.ItemsSource>
                            <MultiBinding Converter="{StaticResource HierarchicalDataConverter}" Mode="TwoWay">
                                <Binding Mode="OneTime"></Binding>
                                <Binding Path="DataContext.Items" ElementName="root" ></Binding>
                                <Binding Path="DataContext.Items.Count" ElementName="root" ></Binding>
                            </MultiBinding>
                        </HierarchicalDataTemplate.ItemsSource>
                        <StackPanel Orientation="Horizontal">
                            <TextBlock Text="{ Binding Name }"></TextBlock>
                            <Button Command="{Binding DataContext.AddLeafe, ElementName=root}" CommandParameter="{Binding}">Add item</Button>
                        </StackPanel>
                    </HierarchicalDataTemplate>
                    <DataTemplate  x:Key="ChildEntityTemplate" DataType="{x:Type vm:ChildEntity}">
                        <TextBlock Text="{Binding Name}"></TextBlock>
                    </DataTemplate>
                </TreeView.Resources>
                <TreeView.ItemsSource>
                    <Binding Path="RootItems"/>
                </TreeView.ItemsSource>
                <TreeView.ItemTemplateSelector>
                    <vm:ItemTemplateSelector>
                    </vm:ItemTemplateSelector>
                </TreeView.ItemTemplateSelector>
            </TreeView>
        </StackPanel> 
