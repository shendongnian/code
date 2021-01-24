    <Style TargetType="{x:Type e:DataGrid}"  BasedOn="{StaticResource {x:Type DataGrid}}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type DataGrid}">
                    <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="True">
                        <ScrollViewer x:Name="DG_ScrollViewer" Focusable="false">
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
                                            <RowDefinition Height="Auto"/>
                                            <RowDefinition Height="*"/>
                                            <RowDefinition Height="Auto"/>
                                        </Grid.RowDefinitions>
                                        <Label Content="{Binding Label, RelativeSource={RelativeSource TemplatedParent}}" ContentStringFormat="{}{0}: " />
                                        <Button Grid.Row="1" Command="{x:Static DataGrid.SelectAllCommand}" Focusable="false" Style="{DynamicResource {ComponentResourceKey ResourceId=DataGridSelectAllButtonStyle, TypeInTargetAssembly={x:Type DataGrid}}}" Visibility="{Binding HeadersVisibility, ConverterParameter={x:Static DataGridHeadersVisibility.All}, Converter={x:Static DataGrid.HeadersVisibilityConverter}, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" Width="{Binding CellsPanelHorizontalOffset, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}"/>
                                        <DataGridColumnHeadersPresenter x:Name="PART_ColumnHeadersPresenter" Grid.Row="1" Grid.Column="1" Visibility="{Binding HeadersVisibility, ConverterParameter={x:Static DataGridHeadersVisibility.Column}, Converter={x:Static DataGrid.HeadersVisibilityConverter}, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}"/>
                                        <ScrollContentPresenter x:Name="PART_ScrollContentPresenter" CanContentScroll="{TemplateBinding CanContentScroll}" Grid.ColumnSpan="2" Grid.Row="2"/>
                                        <ScrollBar x:Name="PART_VerticalScrollBar" Grid.Column="2" Maximum="{TemplateBinding ScrollableHeight}" Orientation="Vertical" Grid.Row="2" Visibility="{TemplateBinding ComputedVerticalScrollBarVisibility}" Value="{Binding VerticalOffset, Mode=OneWay, RelativeSource={RelativeSource TemplatedParent}}" ViewportSize="{TemplateBinding ViewportHeight}"/>
                                        <Grid Grid.Column="1" Grid.Row="3">
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition Width="{Binding NonFrozenColumnsViewportHorizontalOffset, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}"/>
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
                    <Condition Property="IsGrouping" Value="true"/>
                    <Condition Property="VirtualizingPanel.IsVirtualizingWhenGrouping" Value="false"/>
                </MultiTrigger.Conditions>
                <Setter Property="ScrollViewer.CanContentScroll" Value="false"/>
            </MultiTrigger>
        </Style.Triggers>
    </Style>
