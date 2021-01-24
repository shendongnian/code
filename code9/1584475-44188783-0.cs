    <Style x:Key="DropShaodowBorderStyle" TargetType="{x:Type Border}">
                <Setter Property="Effect">
                    <Setter.Value>
                        <DropShadowEffect ShadowDepth="0" BlurRadius="0"></DropShadowEffect>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="Visibility" Value="Visible">
                        <Trigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation Storyboard.TargetProperty="(UIElement.Effect).BlurRadius" From="0" To="80" Duration="0:0:2"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </Trigger.EnterActions>
                        <Trigger.ExitActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation Storyboard.TargetProperty="(UIElement.Effect).BlurRadius" From="80" To="0" Duration="0:0:2"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </Trigger.ExitActions>
                    </Trigger>
                </Style.Triggers>
            </Style>
