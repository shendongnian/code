    <Style.Triggers>
        <EventTrigger RoutedEvent="Window.Loaded">
            <BeginStoryboard Name="sbFadeInFadeOut">
                <Storyboard>
                    <DoubleAnimation Storyboard.TargetProperty="Opacity" Duration="00:00:01" From="0.0" To="0.8" />
                    <DoubleAnimation Storyboard.TargetProperty="Opacity" Duration="00:00:01.5" From="0.8" To="0.0" BeginTime="00:00:04" />
                    <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="(local:WindowAttachedProperties.IsClosed)" BeginTime="00:00:05.5">
                        <DiscreteBooleanKeyFrame Value="True" />
                    </BooleanAnimationUsingKeyFrames>
                </Storyboard>
            </BeginStoryboard>
        </EventTrigger>
    </Style.Triggers>
