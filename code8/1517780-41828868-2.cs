        <SolidColorBrush x:Key="ListBorder" Color="#828790"/>
        <Style x:Key="CustomListViewStyle" TargetType="{x:Type ListView}">
            <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.WindowBrushKey}}"/>
            <Setter Property="BorderBrush" Value="{StaticResource ListBorder}"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="Foreground" Value="#FF042271"/>
            <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Auto"/>
            <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Auto"/>
            <Setter Property="ScrollViewer.CanContentScroll" Value="true"/>
            <Setter Property="ScrollViewer.PanningMode" Value="Both"/>
            <Setter Property="Stylus.IsFlicksEnabled" Value="False"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ListView}">
                        <Themes:ListBoxChrome x:Name="Bd" Background="{TemplateBinding Background}" RenderMouseOver="{TemplateBinding IsMouseOver}" RenderFocused="{TemplateBinding IsKeyboardFocusWithin}" SnapsToDevicePixels="true">
                            <ScrollViewer Padding="{TemplateBinding Padding}" Style="{DynamicResource CustomScrollViewerStyle}">
                                <ItemsPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                            </ScrollViewer>
                        </Themes:ListBoxChrome>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsEnabled" Value="false">
                                <Setter Property="Background" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.ControlBrushKey}}"/>
                            </Trigger>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsGrouping" Value="true"/>
                                    <Condition Property="VirtualizingPanel.IsVirtualizingWhenGrouping" Value="false"/>
                                </MultiTrigger.Conditions>
                                <Setter Property="ScrollViewer.CanContentScroll" Value="false"/>
                            </MultiTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
