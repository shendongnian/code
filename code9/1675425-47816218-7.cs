    <Label.Template>
        <ControlTemplate TargetType="Label">
            <ContentPresenter/>
            <ControlTemplate.Triggers>
                <Trigger Property="IsEnabled" Value="True">
                    <Trigger.EnterActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Content" Duration="00:00:00.8" RepeatBehavior="Forever">
                                    <DiscreteObjectKeyFrame KeyTime="00:00:00.0" Value="Loading"/>
                                    <DiscreteObjectKeyFrame KeyTime="00:00:00.2" Value="Loading."/>
                                    <DiscreteObjectKeyFrame KeyTime="00:00:00.4" Value="Loading.."/>
                                    <DiscreteObjectKeyFrame KeyTime="00:00:00.6" Value="Loading..."/>
                                </ObjectAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </Trigger.EnterActions>
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>
    </Label.Template>
