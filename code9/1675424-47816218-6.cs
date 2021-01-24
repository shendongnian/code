    <StackPanel Orientation="Horizontal">
        <TextBlock Text="Loading"/>
        <TextBlock>
            <TextBlock.Style>
                <Style TargetType="TextBlock">
                    <Style.Triggers>
                        <Trigger Property="IsEnabled" Value="True">
                            <Trigger.EnterActions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Text" Duration="00:00:00.8" RepeatBehavior="Forever">
                                            <DiscreteObjectKeyFrame KeyTime="00:00:00.0" Value=""/>
                                            <DiscreteObjectKeyFrame KeyTime="00:00:00.2" Value="."/>
                                            <DiscreteObjectKeyFrame KeyTime="00:00:00.4" Value=".."/>
                                            <DiscreteObjectKeyFrame KeyTime="00:00:00.6" Value="..."/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </BeginStoryboard>
                            </Trigger.EnterActions>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </TextBlock.Style>
        </TextBlock>
    </StackPanel>
