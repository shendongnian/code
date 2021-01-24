    <ProgressBar Minimum="0" Maximum="100">
        <ProgressBar.Triggers>
            <EventTrigger RoutedEvent="FrameworkElement.Loaded">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation From="0" To="100" Storyboard.TargetProperty="Value" Duration="00:00:10" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </ProgressBar.Triggers>
    </ProgressBar>
