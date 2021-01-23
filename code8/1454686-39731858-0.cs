    <Rectangle x:Name="MuzzleFlash" Height="100" Width="100" Fill="Red">
        <Rectangle.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <BeginStoryboard>
                    <Storyboard>
                        <ObjectAnimationUsingKeyFrames BeginTime="0:0:0.5"  Storyboard.TargetProperty="Visibility">
                            <DiscreteObjectKeyFrame Value="{x:Static Visibility.Collapsed}" />
                        </ObjectAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Rectangle.Triggers>
    </Rectangle>
