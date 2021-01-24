    <Image x:Name="Logo" Source="Resources/Logo.png" RenderTransformOrigin=".5,.5">
        <Image.RenderTransform>
            <RotateTransform/>
        </Image.RenderTransform>
        <Image.Style>
            <Style TargetType="Image">
                <Style.Triggers>
                    <Trigger Property="IsEnabled" Value="True">
                        <Trigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation
                                        Storyboard.TargetProperty="RenderTransform.Angle"
                                        To="360" RepeatBehavior="Forever"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </Trigger.EnterActions>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Image.Style>
    </Image>
