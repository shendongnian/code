     <Page.Resources>
        <Storyboard x:Name="StoryboardZoomIn">
            <DoubleAnimationUsingKeyFrames EnableDependentAnimation="True"
                                           Storyboard.TargetProperty="(Shape.Fill).(Brush.RelativeTransform).(CompositeTransform.ScaleX)"
                                           Storyboard.TargetName="path">
                <EasingDoubleKeyFrame KeyTime="0:0:1"
                                      Value="1.5">
                    <EasingDoubleKeyFrame.EasingFunction>
                        <CubicEase EasingMode="EaseIn" />
                    </EasingDoubleKeyFrame.EasingFunction>
                </EasingDoubleKeyFrame>
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames EnableDependentAnimation="True"
                                           Storyboard.TargetProperty="(Shape.Fill).(Brush.RelativeTransform).(CompositeTransform.ScaleY)"
                                           Storyboard.TargetName="path">
                <EasingDoubleKeyFrame KeyTime="0:0:1"
                                      Value="1.5">
                    <EasingDoubleKeyFrame.EasingFunction>
                        <CubicEase EasingMode="EaseIn" />
                    </EasingDoubleKeyFrame.EasingFunction>
                </EasingDoubleKeyFrame>
            </DoubleAnimationUsingKeyFrames>
        </Storyboard>
        <Storyboard x:Name="StoryboardZoomOut">
            <DoubleAnimationUsingKeyFrames EnableDependentAnimation="True"
                                           Storyboard.TargetProperty="(Shape.Fill).(Brush.RelativeTransform).(CompositeTransform.ScaleX)"
                                           Storyboard.TargetName="path">
                <EasingDoubleKeyFrame KeyTime="0:0:1"
                                      Value="1">
                    <EasingDoubleKeyFrame.EasingFunction>
                        <CubicEase EasingMode="EaseIn" />
                    </EasingDoubleKeyFrame.EasingFunction>
                </EasingDoubleKeyFrame>
            </DoubleAnimationUsingKeyFrames>
            <DoubleAnimationUsingKeyFrames EnableDependentAnimation="True"
                                           Storyboard.TargetProperty="(Shape.Fill).(Brush.RelativeTransform).(CompositeTransform.ScaleY)"
                                           Storyboard.TargetName="path">
                <EasingDoubleKeyFrame KeyTime="0:0:1"
                                      Value="1">
                    <EasingDoubleKeyFrame.EasingFunction>
                        <CubicEase EasingMode="EaseIn" />
                    </EasingDoubleKeyFrame.EasingFunction>
                </EasingDoubleKeyFrame>
            </DoubleAnimationUsingKeyFrames>
        </Storyboard>
    </Page.Resources>
