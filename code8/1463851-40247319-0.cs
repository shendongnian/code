    <TabControl x:Name="tabControl">
        <TabControl.Resources>
            <Style x:Key="tabItemStyle" TargetType="TabItem">
                <Setter Property="FocusVisualStyle">
                    <Setter.Value>
                        <Style>
                            <Setter Property="Control.Template">
                                <Setter.Value>
                                    <ControlTemplate>
                                        <Rectangle Margin="2,2,42,2" SnapsToDevicePixels="True"
                                                Stroke="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"
                                                StrokeDashArray="1 2" StrokeThickness="1" />
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </Setter.Value>
                </Setter>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type TabItem}">
                            <Grid x:Name="templateRoot" Margin="0,0,40,0">
                                <Border BorderBrush="LightGray" BorderThickness="1" />
                                <ContentPresenter Margin="10,5" ContentSource="Header" />
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </TabControl.Resources>
        <TabItem Header="TabItem" Style="{StaticResource tabItemStyle}" />
        <TabItem Header="TabItem" Style="{StaticResource tabItemStyle}" />
        <TabItem Header="TabItem" Style="{StaticResource tabItemStyle}" />
    </TabControl>
