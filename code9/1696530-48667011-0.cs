    <ListView Height="100" Background="Yellow">
        <ListView.Style>
            <Style TargetType="ListView">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ListView}">
                            <Grid>
                                <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" 
                                                        BorderThickness="{TemplateBinding BorderThickness}" 
                                                        Background="{TemplateBinding Background}" Padding="1"
                                                        SnapsToDevicePixels="true"
                                                        Opacity="0.5">
                                </Border>
                                <ScrollViewer Focusable="false" Padding="{TemplateBinding Padding}" Margin="{TemplateBinding BorderThickness}">
                                    <ItemsPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                </ScrollViewer>
                            </Grid>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsEnabled" Value="false">
                                    <Setter Property="Background" TargetName="Bd" Value="#FFFFFFFF"/>
                                    <Setter Property="BorderBrush" TargetName="Bd" Value="#FFD9D9D9"/>
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
        </ListView.Style>
        <ListViewItem Background="Yellow">1</ListViewItem>
        <ListViewItem Background="Yellow">2</ListViewItem>
        <ListViewItem Background="Yellow">3</ListViewItem>
    </ListView>
