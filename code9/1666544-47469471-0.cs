                        <ControlTemplate.Triggers>
                            <Trigger Property="IsDefaulted" Value="true">
                                <Setter Property="BorderBrush" TargetName="border" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                            </Trigger>
                            <Trigger Property="IsMouseOver" Value="true">
        --- Delete this line    <Setter Property="Background" TargetName="border" Value="{StaticResource Button.MouseOver.Background}"/>
        --- Delete this line    <Setter Property="BorderBrush" TargetName="border" Value="{StaticResource Button.MouseOver.Border}"/>
                            </Trigger>
                            <Trigger Property="IsPressed" Value="true">
