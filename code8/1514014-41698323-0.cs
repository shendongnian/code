    <Border Background="Transparent">
        <Border.Triggers>
            <EventTrigger RoutedEvent="Border.MouseEnter">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard TargetProperty="(Border.Background).(SolidColorBrush.Color)">
                            <ColorAnimation From="Red" To="Green" Duration="0:0:2" AutoReverse="True" RepeatBehavior="Forever" />
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
        </Border.Triggers>
        <TextBlock>Border....</TextBlock>
    </Border>
