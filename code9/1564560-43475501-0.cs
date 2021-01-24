    <Button Content="Button!">
        <Button.Triggers>
            <EventTrigger RoutedEvent="Button.Click">
                <BeginStoryboard>
                    <Storyboard>
                        <ObjectAnimationUsingKeyFrames Storyboard.Target="{x:Reference dataGrid}"
                                                       Storyboard.TargetProperty="Visibility">
                            <DiscreteObjectKeyFrame KeyTime="0:0:0"
                                                    Value="{x:Static Visibility.Visible}"/>
                        </ObjectAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Button.Triggers>
    </Button>
