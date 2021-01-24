    <Window.Resources>
            <Style x:Key="TreeViewItemStyle" TargetType="{x:Type TreeViewItem}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type TreeViewItem}">
                            <Grid Margin="{Binding Margin}">
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition MinWidth="20" Width="Auto"/>
                                    <ColumnDefinition Width="Auto"/>
                                    <ColumnDefinition Width="*"/>
                                </Grid.ColumnDefinitions>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto"/>
                                    <RowDefinition Height="*"></RowDefinition>
                                </Grid.RowDefinitions>
                                <ToggleButton Grid.Column="0" x:Name="Expander" ClickMode="Press" IsChecked="{Binding IsExpanded, RelativeSource={RelativeSource TemplatedParent}}" />
                                <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Grid.Row="0" Grid.Column="1" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="true">
                                    <ContentPresenter x:Name="PART_Header" ContentSource="Header" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                </Border>
                                <ItemsPresenter x:Name="ItemsHost" Grid.ColumnSpan="2" Grid.Column="1" Grid.Row="1" Margin="-10,0,0,0"/>
                            </Grid>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsExpanded" Value="false">
                                    <Setter Property="Visibility" TargetName="ItemsHost" Value="Collapsed"/>
                                </Trigger>
                                <Trigger Property="HasItems" Value="false">
                                    <Setter Property="Visibility" TargetName="Expander" Value="Hidden"/>
                                </Trigger>
                                <Trigger Property="IsSelected" Value="true">
                                    <Setter Property="Background" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                                    <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}"/>
                                </Trigger>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="IsSelected" Value="true"/>
                                        <Condition Property="IsSelectionActive" Value="false"/>
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Background" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}"/>
                                    <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
                                </MultiTrigger>
                                <Trigger Property="IsEnabled" Value="false">
                                    <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="VirtualizingStackPanel.IsVirtualizing" Value="true">
                        <Setter Property="ItemsPanel">
                            <Setter.Value>
                                <ItemsPanelTemplate>
                                    <VirtualizingStackPanel/>
                                </ItemsPanelTemplate>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Window.Resources>
    
        <TreeView ItemsSource="{Binding TreeItems}" ItemContainerStyle="{StaticResource TreeViewItemStyle}">
            <TreeView.Resources>
                <HierarchicalDataTemplate DataType="{x:Type library:MyModel}" ItemsSource="{Binding Children}" >
                    <TextBlock Text="{Binding Name}"></TextBlock>
                </HierarchicalDataTemplate>
            </TreeView.Resources>
        </TreeView>
