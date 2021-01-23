    <Grid>
            <Grid.Resources>
                <Storyboard x:Key="ChrisW-shapeTransform">
                    <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)" Storyboard.TargetName="grid">
                        <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="90"/>
                    </DoubleAnimationUsingKeyFrames>
                    <PointAnimationUsingKeyFrames Storyboard.TargetProperty="(Path.Data).(PathGeometry.Figures)[0].(PathFigure.Segments)[1].(LineSegment.Point)" Storyboard.TargetName="path">
                        <EasingPointKeyFrame KeyTime="0:0:0.2" Value="35,25"/>
                    </PointAnimationUsingKeyFrames>
                    <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Height)" Storyboard.TargetName="path">
                        <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="10"/>
                    </DoubleAnimationUsingKeyFrames>
                    <PointAnimationUsingKeyFrames Storyboard.TargetProperty="(Path.Data).(PathGeometry.Figures)[0].(PathFigure.Segments)[2].(LineSegment.Point)" Storyboard.TargetName="path1">
                        <EasingPointKeyFrame KeyTime="0:0:0.2" Value="34.9687517366199,8.02473365979495E-07"/>
                    </PointAnimationUsingKeyFrames>
                    <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Height)" Storyboard.TargetName="path1">
                        <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="10"/>
                    </DoubleAnimationUsingKeyFrames>
                    <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Shape.Fill).(SolidColorBrush.Color)" Storyboard.TargetName="path1">
                        <EasingColorKeyFrame KeyTime="0:0:0.2" Value="#FFB60303"/>
                    </ColorAnimationUsingKeyFrames>
                    <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Shape.Fill).(SolidColorBrush.Color)" Storyboard.TargetName="path">
                        <EasingColorKeyFrame KeyTime="0:0:0.2" Value="#FFB60303"/>
                    </ColorAnimationUsingKeyFrames>
                </Storyboard>
            </Grid.Resources>
            <Grid.Triggers>
                <EventTrigger RoutedEvent="UIElement.MouseEnter">
                    <BeginStoryboard Storyboard="{StaticResource ChrisW-shapeTransform}"/>
                </EventTrigger>
            </Grid.Triggers>
    
            <Grid x:Name="grid" HorizontalAlignment="Center" VerticalAlignment="Center" RenderTransformOrigin="0.5,0.5">
                <Grid.RenderTransform>
                    <TransformGroup>
                        <ScaleTransform/>
                        <SkewTransform/>
                        <RotateTransform/>
                        <TranslateTransform/>
                    </TransformGroup>
                </Grid.RenderTransform>
                <Path x:Name="path1" Fill="#FF23B603" Margin="0,0,0,25" Width="35" Height="25">
                    <Path.Data>
                        <PathGeometry>
                            <PathFigure IsClosed="True" StartPoint="3.40174928936676E-06,8.28996221002853E-07">
                                <LineSegment Point="3.40174928936676E-06,25.0000021090614"/>
                                <LineSegment Point="34.9999995333882,25.0000021090614"/>
                                <LineSegment Point="24.2397154485391,17.2785287275999"/>
                            </PathFigure>
                        </PathGeometry>
                    </Path.Data>
                </Path>
                <Path x:Name="path" Fill="#FF23B603" Height="25" Width="35" Margin="0,25,0,0">
                    <Path.Data>
                        <PathGeometry>
                            <PathFigure IsClosed="True" StartPoint="0,0">
                                <LineSegment Point="35.0000012644377,0"/>
                                <LineSegment Point="24.2397160835937,7.72147280089242"/>
                                <LineSegment Point="0,24.9999997857589"/>
                            </PathFigure>
                        </PathGeometry>
                    </Path.Data>
                </Path>
            </Grid>
    
        </Grid>
