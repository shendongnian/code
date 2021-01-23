    <Style TargetType="Popup">
      <Style.Triggers>
        <MultiDataTrigger>
            <MultiDataTrigger.Conditions>
                <Condition Binding="{Binding PlacementTarget.IsMouseOver, RelativeSource={RelativeSource Self}}" Value="True" />
                <!-- add your other condtion here that determines whether there are any items in the Popup, e.g.: -->
                <Condition Binding="{Binding Items.Count, RelativeSource={RelativeSource Self}}" Value="0" />
            </MultiDataTrigger.Conditions>
            <MultiDataTrigger.EnterActions>
                <BeginStoryboard x:Name="OpenPopupStoryBoard" >
                    <Storyboard>
                        <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen" FillBehavior="HoldEnd">
                            <DiscreteBooleanKeyFrame KeyTime="0:0:0.10"  Value="True"/>
                        </BooleanAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>
            </MultiDataTrigger.EnterActions>
            <MultiDataTrigger.ExitActions>
                <PauseStoryboard BeginStoryboardName="OpenPopupStoryBoard"/>
                <BeginStoryboard x:Name="ClosePopupStoryBoard">
                    <Storyboard>
                        <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen" FillBehavior="HoldEnd">
                            <DiscreteBooleanKeyFrame KeyTime="0:0:0.2" Value="False"/>
                        </BooleanAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>
            </MultiDataTrigger.ExitActions>
        </MultiDataTrigger>
        <Trigger Property="IsMouseOver" Value="True">
            <Trigger.EnterActions>
                <PauseStoryboard BeginStoryboardName="ClosePopupStoryBoard" />
            </Trigger.EnterActions>
            <Trigger.ExitActions>
                <PauseStoryboard BeginStoryboardName="OpenPopupStoryBoard"/>
                <ResumeStoryboard BeginStoryboardName="ClosePopupStoryBoard" />
            </Trigger.ExitActions>
        </Trigger>
    </Style.Triggers>
