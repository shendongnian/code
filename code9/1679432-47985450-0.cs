           <ToggleButton x:Name="ProductToggleButton" Content="Products">
                <ToggleButton.Triggers>
                    <EventTrigger RoutedEvent="ToggleButton.Checked">
                        <BeginStoryboard>
                            <Storyboard >
                                <DoubleAnimation Storyboard.TargetName="HideableStackPanel" Storyboard.TargetProperty="RenderTransform.ScaleY" From="0" To="1" Duration="0:00:.300"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                    <EventTrigger RoutedEvent="ToggleButton.Unchecked">
                        <BeginStoryboard>
                            <Storyboard >
                                <DoubleAnimation Storyboard.TargetName="HideableStackPanel" Storyboard.TargetProperty="RenderTransform.ScaleY" From="1" To="0" Duration="0:00:.300"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </ToggleButton.Triggers>
            </ToggleButton>
            <StackPanel x:Name="HideableStackPanel" >
                <StackPanel.RenderTransform>
                    <ScaleTransform ScaleY="0"></ScaleTransform>
                </StackPanel.RenderTransform>
                <ToggleButton  Padding="30,0,0,0" Content="Menu Item"/>
            </StackPanel>
