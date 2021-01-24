     <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="True">
                    <Trigger.EnterActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <ThicknessAnimation Duration="0:0:0.250" To="0" 
                                                                Storyboard.TargetProperty="BorderThickness" />
                                <DoubleAnimation Duration="0:0:0.550" To="120" 
                                                                Storyboard.TargetProperty="Height" />
                                <DoubleAnimation Duration="0:0:0.550" To="120" 
                                                                Storyboard.TargetProperty="Width" />
                            </Storyboard>
                        </BeginStoryboard>
                    </Trigger.EnterActions>
                    <Trigger.ExitActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <ThicknessAnimation Duration="0:0:0.250" To="0" 
                                                                Storyboard.TargetProperty="BorderThickness" />
                                <DoubleAnimation Duration="0:0:0.550" To="100" 
                                                                Storyboard.TargetProperty="Height" />
                                <DoubleAnimation Duration="0:0:0.550" To="100" 
                                                                Storyboard.TargetProperty="Width" />
                            </Storyboard>
                        </BeginStoryboard>
                    </Trigger.ExitActions>
                </Trigger>
            </Style.Triggers>
