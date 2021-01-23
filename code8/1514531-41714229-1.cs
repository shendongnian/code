     <Style x:Key="ListBoxStyleVirtualize" BasedOn="{StaticResource ListBoxMainStyle}" TargetType="{x:Type ListBox}">
            <Setter Property="ScrollViewer.CanContentScroll" Value="True"/>
            <Setter Property="ItemsPanel">
                <Setter.Value>
                    <ItemsPanelTemplate>
                        <custom:VirtualizingTilePanel Name="VirtHost" IsItemsHost="True" HorizontalAlignment="Center" VirtualizingPanel.VirtualizationMode="Recycling" Margin="0 0 0 23"/>
                    </ItemsPanelTemplate>
                </Setter.Value>
            </Setter>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ListBox}">
                        <Grid>
                            <Border CornerRadius="0" x:Name="Bd" BorderBrush="Transparent" BorderThickness="0" SnapsToDevicePixels="true">
                                <ScrollViewer Focusable="false" MouseLeftButtonDown="ScrollViewer_MouseLeftButtonDown" Padding="{TemplateBinding Padding}" Template="{DynamicResource ScrollViewerControlTemplate1}">
                                    <ItemsPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                </ScrollViewer>
                            </Border>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsEnabled" Value="false">
                                <Setter Property="Background" TargetName="Bd" Value="Transparent"/>
                            </Trigger>
                            <Trigger Property="IsGrouping" Value="true">
                                <Setter Property="ScrollViewer.CanContentScroll" Value="false"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
