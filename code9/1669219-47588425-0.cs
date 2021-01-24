     <Trigger Property="Visibility" Value="Visible">
                        <Trigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard >
                                    <DoubleAnimation Storyboard.TargetProperty="Width"
                                                     From="0" To="150" 
                                                     DecelerationRatio="0.5" 
                                                     Duration="00:00:01.000"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </Trigger.EnterActions>
                    </Trigger>
