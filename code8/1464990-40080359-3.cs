       <TextBox x:Name="Tbx" Text="type something here...">
            <TextBox.Triggers>
                <EventTrigger RoutedEvent="LostFocus">
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Duration="00:00:03" Storyboard.TargetProperty="Opacity" To="0" />
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </TextBox.Triggers>
        </TextBox>
