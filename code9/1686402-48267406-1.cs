    <Style x:Key="WatermarkTextBox"  TargetType="{x:Type TextBox}">
        <Setter Property="FontSize" Value="12" />
        <Setter Property="Background" Value="Transparent" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type TextBoxBase}">
                    <Grid>
                        <Border
                            x:Name="border"
                            SnapsToDevicePixels="True">
                            <ScrollViewer
                                x:Name="PART_ContentHost"
                                Focusable="False"
                                HorizontalScrollBarVisibility="Hidden"
                                VerticalScrollBarVisibility="Hidden" />
                        </Border>
                        <TextBlock
                            x:Name="placeholder"
                            Padding="{TemplateBinding Padding}"
                            VerticalAlignment="Center"
                            IsHitTestVisible="False"
                            Text="{TemplateBinding Tag}">
                            <TextBlock.Style>
                                <Style TargetType="{x:Type TextBlock}">
                                    <Setter Property="Visibility" Value="Collapsed" />
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding Text, RelativeSource={RelativeSource TemplatedParent}}" Value="">
                                            <Setter Property="Visibility" Value="Visible" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </TextBlock.Style>
                        </TextBlock>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsEnabled" Value="False">
                            <Setter TargetName="border" Property="Opacity" Value="0.56" />
                        </Trigger>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter TargetName="border" Property="BorderBrush" Value="#FF7EB4EA" />
                        </Trigger>
                        <Trigger Property="IsKeyboardFocused" Value="True">
                            <Setter TargetName="border" Property="BorderBrush" Value="#FF569DE5" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
