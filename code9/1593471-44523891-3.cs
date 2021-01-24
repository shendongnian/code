    <EventTrigger RoutedEvent="UiElement.Click">
        <BeginStoryboard>
            <Storyboard>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="Width" >
                    <EasingDoubleKeyFrame KeyTime="0:0:0" Value="90"/>
                </DoubleAnimationUsingKeyFrames>
             </Storyboard>
        </BeginStoryboard>
    </EventTrigger>
