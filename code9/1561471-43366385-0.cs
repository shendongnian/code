    <TextBox Background="Yellow" Text="test">
        <TextBox.Template>
            <ControlTemplate TargetType="{x:Type TextBox}">
                <Border x:Name="border" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" SnapsToDevicePixels="True">
                    <ScrollViewer x:Name="PART_ContentHost" Focusable="false" HorizontalScrollBarVisibility="Hidden" VerticalScrollBarVisibility="Hidden">
                        <ScrollViewer.LayoutTransform>
                            <RotateTransform Angle="-90"></RotateTransform>
                        </ScrollViewer.LayoutTransform>
                    </ScrollViewer>
                </Border>
                <ControlTemplate.Triggers>
                    <Trigger Property="IsEnabled" Value="false">
                        <Setter Property="Opacity" TargetName="border" Value="0.56"/>
                    </Trigger>
                    <Trigger Property="IsMouseOver" Value="true">
                        <Setter Property="BorderBrush" TargetName="border" Value="#FF7EB4EA"/>
                    </Trigger>
                    <Trigger Property="IsKeyboardFocused" Value="true">
                        <Setter Property="BorderBrush" TargetName="border" Value="#FF569DE5"/>
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </TextBox.Template>
    </TextBox>
