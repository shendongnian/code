    <Storyboard x:Name="myStoryboard">
        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="myImage"
                                       Storyboard.TargetProperty="(Canvas.Top)">
            <SplineDoubleKeyFrame KeyTime="0:0:0" Value="100" />
            <SplineDoubleKeyFrame x:Name="MyTopSpline" KeyTime="0:0:1.9" Value="100" />
        </DoubleAnimationUsingKeyFrames>
    
        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="myImage"
                                       Storyboard.TargetProperty="(Canvas.Left)">
            <SplineDoubleKeyFrame KeyTime="0:0:0" Value="200" />
            <SplineDoubleKeyFrame x:Name="MyLeftSpline" KeyTime="0:0:1.9" Value="200" />
        </DoubleAnimationUsingKeyFrames>
        <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.Rotation)"
                                       Storyboard.TargetName="myImage">
            <EasingDoubleKeyFrame KeyTime="0" Value="0" />
            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="0" />
            <EasingDoubleKeyFrame KeyTime="0:0:2.9" Value="360" />
        </DoubleAnimationUsingKeyFrames>
        <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.ScaleX)"
                                       Storyboard.TargetName="myImage">
            <EasingDoubleKeyFrame KeyTime="0" Value="1" />
            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1" />
            <EasingDoubleKeyFrame KeyTime="0:0:1.9" Value="1" />
            <EasingDoubleKeyFrame KeyTime="0:0:2.8" Value="0" />
        </DoubleAnimationUsingKeyFrames>
        <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.ScaleY)"
                                       Storyboard.TargetName="myImage">
            <EasingDoubleKeyFrame KeyTime="0" Value="1" />
            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1" />
            <EasingDoubleKeyFrame KeyTime="0:0:1.9" Value="1" />
            <EasingDoubleKeyFrame KeyTime="0:0:2.8" Value="0" />
        </DoubleAnimationUsingKeyFrames>
        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                       Storyboard.TargetName="myImage">
            <DiscreteObjectKeyFrame KeyTime="0">
                <DiscreteObjectKeyFrame.Value>
                    <Visibility>Visible</Visibility>
                </DiscreteObjectKeyFrame.Value>
            </DiscreteObjectKeyFrame>
            <DiscreteObjectKeyFrame KeyTime="0:0:3">
                <DiscreteObjectKeyFrame.Value>
                    <Visibility>Collapsed</Visibility>
                </DiscreteObjectKeyFrame.Value>
            </DiscreteObjectKeyFrame>
        </ObjectAnimationUsingKeyFrames>
    </Storyboard>
