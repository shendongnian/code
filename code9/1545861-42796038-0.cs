    <Style x:Key="DataGridStyle1" TargetType="{x:Type DataGrid}">
        <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}"/>
        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
        <Setter Property="BorderBrush" Value="#FF688CAF"/>
        <Setter Property="BorderThickness" Value="1"/>
        <Setter Property="RowDetailsVisibilityMode" Value="VisibleWhenSelected"/>
        <Setter Property="ScrollViewer.CanContentScroll" Value="True"/>
        <Setter Property="ScrollViewer.PanningMode" Value="Both"/>
        <Setter Property="Stylus.IsFlicksEnabled" Value="False"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type DataGrid}">
                    <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="True">
                        <ScrollViewer x:Name="DG_ScrollViewer" Focusable="False">
                            <ScrollViewer.Template>
                                <ControlTemplate TargetType="{x:Type ScrollViewer}">
                                    <Grid>
                                        <Grid.ColumnDefinitions>
                                            <ColumnDefinition Width="Auto"/>
                                            <ColumnDefinition Width="*"/>
                                            <ColumnDefinition Width="Auto"/>
                                        </Grid.ColumnDefinitions>
                                        <Grid.RowDefinitions>
                                            <RowDefinition Height="Auto"/>
                                            <RowDefinition Height="*"/>
                                            <RowDefinition Height="Auto"/>
                                        </Grid.RowDefinitions>
                                        <Button Command="ApplicationCommands.SelectAll" Focusable="False" Style="{DynamicResource {ComponentResourceKey ResourceId=DataGridSelectAllButtonStyle, TypeInTargetAssembly={x:Type DataGrid}}}" Width="{Binding CellsPanelHorizontalOffset, RelativeSource={RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type DataGrid}}}">
                                            <Button.Visibility>
                                                <Binding Path="HeadersVisibility" RelativeSource="{RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type DataGrid}}">
                                                    <Binding.ConverterParameter>
                                                        <DataGridHeadersVisibility>All</DataGridHeadersVisibility>
                                                    </Binding.ConverterParameter>
                                                </Binding>
                                            </Button.Visibility>
                                        </Button>
                                        <DataGridColumnHeadersPresenter x:Name="PART_ColumnHeadersPresenter" Grid.Column="1">
                                            <DataGridColumnHeadersPresenter.Visibility>
                                                <Binding Path="HeadersVisibility" RelativeSource="{RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type DataGrid}}">
                                                    <Binding.ConverterParameter>
                                                        <DataGridHeadersVisibility>Column</DataGridHeadersVisibility>
                                                    </Binding.ConverterParameter>
                                                </Binding>
                                            </DataGridColumnHeadersPresenter.Visibility>
                                        </DataGridColumnHeadersPresenter>
                                        <Grid Background="White" Grid.Column="2" /> <!-- HERE IS THE GRID -->
                                        <ScrollContentPresenter x:Name="PART_ScrollContentPresenter" CanContentScroll="{TemplateBinding CanContentScroll}" CanHorizontallyScroll="False" Grid.ColumnSpan="2" CanVerticallyScroll="False" ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" ContentStringFormat="{TemplateBinding ContentStringFormat}" Grid.Row="1"/>
                                        <ScrollBar x:Name="PART_VerticalScrollBar" Grid.Column="2" Maximum="{TemplateBinding ScrollableHeight}" Orientation="Vertical" Grid.Row="1" Visibility="{TemplateBinding ComputedVerticalScrollBarVisibility}" Value="{Binding VerticalOffset, Mode=OneWay, RelativeSource={RelativeSource TemplatedParent}}" ViewportSize="{TemplateBinding ViewportHeight}"/>
                                        <Grid Grid.Column="1" Grid.Row="2">
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition Width="{Binding NonFrozenColumnsViewportHorizontalOffset, RelativeSource={RelativeSource FindAncestor, AncestorLevel=1, AncestorType={x:Type DataGrid}}}"/>
                                                <ColumnDefinition Width="*"/>
                                            </Grid.ColumnDefinitions>
                                            <ScrollBar x:Name="PART_HorizontalScrollBar" Grid.Column="1" Maximum="{TemplateBinding ScrollableWidth}" Orientation="Horizontal" Visibility="{TemplateBinding ComputedHorizontalScrollBarVisibility}" Value="{Binding HorizontalOffset, Mode=OneWay, RelativeSource={RelativeSource TemplatedParent}}" ViewportSize="{TemplateBinding ViewportWidth}"/>
                                        </Grid>
                                    </Grid>
                                </ControlTemplate>
                            </ScrollViewer.Template>
                            <ItemsPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                        </ScrollViewer>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsGrouping" Value="True"/>
                    <Condition Property="VirtualizingPanel.IsVirtualizingWhenGrouping" Value="False"/>
                </MultiTrigger.Conditions>
                <Setter Property="ScrollViewer.CanContentScroll" Value="False"/>
            </MultiTrigger>
        </Style.Triggers>
    </Style>
