       <!-- Pulse -->
    <Storyboard x:Key="Pulse" RepeatBehavior="Forever">
        <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)" Storyboard.TargetName="PulseBox">
            <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="1.22"/>
            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1"/>
        </DoubleAnimationUsingKeyFrames>
        <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)" Storyboard.TargetName="PulseBox">
            <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="1.22"/>
            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="1"/>
        </DoubleAnimationUsingKeyFrames>
    </Storyboard> 
    <Ellipse x:Name="PulseBox" Fill="#FFCA2437" Width="14" Height="14"  RenderTransformOrigin="0.5,0.5">
                        <Ellipse.RenderTransform>
                            <TransformGroup>
                                <ScaleTransform/>
                                <SkewTransform/>
                                <RotateTransform/>
                                <TranslateTransform/>
                            </TransformGroup>
                        </Ellipse.RenderTransform>
                        <Ellipse.Effect>
                            <BlurEffect Radius="3"  KernelType="Gaussian"/>
                        </Ellipse.Effect>
                    </Ellipse>
