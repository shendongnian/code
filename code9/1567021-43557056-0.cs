    <!--add needed namespaces-->
    xmlns:interactivity="using:Microsoft.Xaml.Interactivity"
    xmlns:icore="using:Microsoft.Xaml.Interactions.Core"
    xmlns:imedia="using:Microsoft.Xaml.Interactions.Media"
    <Button x:Name="button" >
        <Button.Projection>
            <PlaneProjection RotationZ="50"/>
        </Button.Projection>
        <interactivity:Interaction.Behaviors>
            <icore:EventTriggerBehavior EventName="Click" SourceObject="{Binding ElementName=button}">
                <imedia:ControlStoryboardAction>
                    <imedia:ControlStoryboardAction.Storyboard>
                        <Storyboard x:Name="Storyboard1">
                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Projection).(PlaneProjection.RotationZ)" Storyboard.TargetName="button">
                                <EasingDoubleKeyFrame KeyTime="0" Value="50"/>
                                <EasingDoubleKeyFrame KeyTime="0:0:2" Value="320"/>
                            </DoubleAnimationUsingKeyFrames>
                        </Storyboard>
                    </imedia:ControlStoryboardAction.Storyboard>
                </imedia:ControlStoryboardAction>
            </icore:EventTriggerBehavior>
        </interactivity:Interaction.Behaviors>
    </Button>
