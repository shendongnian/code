    <Style x:Key="SplitViewStyle1" TargetType="SplitView">
            ...
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="SplitView">
                        <Grid Background="{TemplateBinding Background}">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition x:Name="ColumnDefinition1" Width="{Binding TemplateSettings.OpenPaneGridLength, FallbackValue=0, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                <ColumnDefinition x:Name="ColumnDefinition2" Width="*"/>
                            </Grid.ColumnDefinitions>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="DisplayModeStates">
                                    <VisualStateGroup.Transitions>
                                        <VisualTransition From="Closed" To="OpenOverlayLeft">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PaneRoot" Storyboard.TargetProperty="Visibility">
                                                    <DiscreteObjectKeyFrame KeyTime="0:0:3" Value="Visible"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="HCPaneBorder" Storyboard.TargetProperty="Visibility">
                                                    <DiscreteObjectKeyFrame KeyTime="0:0:3" Value="Visible"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <DoubleAnimationUsingKeyFrames Storyboard.TargetName="PaneTransform" Storyboard.TargetProperty="TranslateX">
                                                    <DiscreteDoubleKeyFrame KeyTime="0:0:0" Value="{Binding TemplateSettings.NegativeOpenPaneLength, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                                    <SplineDoubleKeyFrame KeySpline="0.1,0.9 0.2,1.0" KeyTime="0:0:0.35" Value="0"/>
                                                </DoubleAnimationUsingKeyFrames>
                                                <DoubleAnimationUsingKeyFrames Storyboard.TargetName="PaneClipRectangleTransform" Storyboard.TargetProperty="TranslateX">
                                                    <DiscreteDoubleKeyFrame KeyTime="0:0:0" Value="{Binding TemplateSettings.OpenPaneLength, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                                    <SplineDoubleKeyFrame KeySpline="0.1,0.9 0.2,1.0" KeyTime="0:0:0.35" Value="0"/>
                                                </DoubleAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="LightDismissLayer" Storyboard.TargetProperty="Visibility">
                                                    <DiscreteObjectKeyFrame KeyTime="0:0:3" Value="Visible"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <DoubleAnimationUsingKeyFrames Storyboard.TargetName="LightDismissLayer" Storyboard.TargetProperty="Opacity">
                                                    <DiscreteDoubleKeyFrame KeyTime="0:0:0" Value="0.0"/>
                                                    <SplineDoubleKeyFrame KeySpline="0.1,0.9 0.2,1.0" KeyTime="0:0:0.35" Value="1.0"/>
                                                </DoubleAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualTransition>
                                        ......
                            </VisualStateManager.VisualStateGroups>
                            <Grid x:Name="PaneRoot" Background="{TemplateBinding PaneBackground}" Grid.ColumnSpan="2" HorizontalAlignment="Left" Visibility="Collapsed" Width="{Binding TemplateSettings.OpenPaneLength, RelativeSource={RelativeSource Mode=TemplatedParent}}" Canvas.ZIndex="1">
                                <Grid.Clip>
                                    <RectangleGeometry x:Name="PaneClipRectangle">
                                        <RectangleGeometry.Transform>
                                            <CompositeTransform x:Name="PaneClipRectangleTransform"/>
                                        </RectangleGeometry.Transform>
                                    </RectangleGeometry>
                                </Grid.Clip>
                                <Grid.RenderTransform>
                                    <CompositeTransform x:Name="PaneTransform"/>
                                </Grid.RenderTransform>
                                <Border Child="{TemplateBinding Pane}"/>
                                <Rectangle x:Name="HCPaneBorder" Fill="{ThemeResource SystemControlForegroundTransparentBrush}" HorizontalAlignment="Right" Visibility="Collapsed" Width="1" x:DeferLoadStrategy="Lazy"/>
                            </Grid>
                            <Grid x:Name="ContentRoot" Grid.ColumnSpan="2">
                                <Border Child="{TemplateBinding Content}"/>
                                <Rectangle x:Name="LightDismissLayer" Fill="Transparent" Visibility="Collapsed"/>
                            </Grid>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
