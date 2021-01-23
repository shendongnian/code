    <Window.Resources>
        <local:IsNodeConverter x:Key="IsNodeConverter"/>
    </Window.Resources>
    
    ...
    
        <TreeView ItemsSource="{Binding AllNodesAndEntries}">
            <TreeView.Resources>
                
                ...
                
            </TreeView.Resources>
            <TreeView.ItemContainerStyle>
                <Style TargetType="{x:Type TreeViewItem}">
                    <Style.Triggers>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition  Binding="{Binding DataContext.MyProp, RelativeSource={RelativeSource AncestorType={x:Type Window}}}"
                                            Value="True"/>
                                <Condition  Binding="{Binding Converter={StaticResource IsNodeConverter}}"
                                            Value="False"/>
                            </MultiDataTrigger.Conditions>
                            <MultiDataTrigger.Setters>
                                <Setter Property="Focusable" Value="False"></Setter>
                            </MultiDataTrigger.Setters>
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </TreeView.ItemContainerStyle>
        </TreeView>
