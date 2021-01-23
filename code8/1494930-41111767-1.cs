    <Style TargetType="{x:Type local:MyProgressBar}">
        <Setter Property="Foreground" Value="#FF06B025" />
        <Setter Property="Background" Value="#FFE6E6E6" />
        <Setter Property="BorderBrush" Value="#FFBCBCBC" />
        <Setter Property="BorderThickness" Value="1" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:MyProgressBar}">
                    <Grid x:Name="TemplateRoot">
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CommonStates">
                                <VisualState x:Name="Indeterminate">
                                    <Storyboard RepeatBehavior="Forever">
                                        <PointAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransformOrigin)"
                                                                      Storyboard.TargetName="Animation">
                                            <EasingPointKeyFrame KeyTime="0" Value="-0.5,0.5" />
                                            <EasingPointKeyFrame KeyTime="0:0:1" Value="0.5,0.5" />
                                            <EasingPointKeyFrame KeyTime="0:0:2" Value="1.5,0.5" />
                                        </PointAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="IndeterminateAutoReverse">
                                    <Storyboard AutoReverse="True" RepeatBehavior="Forever">
                                        <PointAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransformOrigin)"
                                                                      Storyboard.TargetName="Animation">
                                            <EasingPointKeyFrame KeyTime="0" Value="-0.5,0.5" />
                                            <EasingPointKeyFrame KeyTime="0:0:1" Value="0.5,0.5" />
                                            <EasingPointKeyFrame KeyTime="0:0:2" Value="1.5,0.5" />
                                        </PointAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <Border BorderBrush="{TemplateBinding BorderBrush}"
                                BorderThickness="{TemplateBinding BorderThickness}"
                                Background="{TemplateBinding Background}" />
                        <Rectangle x:Name="PART_Track" />
                        <Grid x:Name="PART_Indicator"
                              ClipToBounds="true"
                              HorizontalAlignment="Left">
                            <Rectangle x:Name="Indicator"
                                       Fill="{TemplateBinding Foreground}" />
                            <Rectangle x:Name="Animation"
                                       Fill="{TemplateBinding Foreground}"
                                       RenderTransformOrigin="0.5,0.5">
                                <Rectangle.RenderTransform>
                                    <TransformGroup>
                                        <ScaleTransform ScaleX="0.25" />
                                    </TransformGroup>
                                </Rectangle.RenderTransform>
                            </Rectangle>
                        </Grid>
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsIndeterminate" Value="true">
                            <Setter Property="Visibility" TargetName="Indicator" Value="Collapsed" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
