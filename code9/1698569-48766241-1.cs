    <ToggleButton Margin="100">
        <ToggleButton.Template>
            <ControlTemplate TargetType="ToggleButton">
                <Border Background="Red">
                    <Border.RenderTransform>
                        <RotateTransform x:Name="rotRect" Angle="0"/>
                    </Border.RenderTransform>
                    <Polygon Points="12,12 12,26, 22,19" Fill="#4B86B1" Margin="0,0,5,0" RenderTransformOrigin="0.6,0.5">
                        <Polygon.Effect>
                            <DropShadowEffect ShadowDepth="0.5" Direction="0" Color="Black"  Opacity="1" BlurRadius="1"/>
                        </Polygon.Effect>
                    </Polygon>
                </Border>
                <ControlTemplate.Triggers>
                    <EventTrigger RoutedEvent="ToggleButton.Checked">
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetName="rotRect" Storyboard.TargetProperty="Angle" From="0" To="90" Duration="0:0:0.5"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                    <EventTrigger RoutedEvent="ToggleButton.Unchecked">
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetName="rotRect" Storyboard.TargetProperty="Angle" From="90" To="0" Duration="0:0:0.5"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </ToggleButton.Template>
    </ToggleButton>
