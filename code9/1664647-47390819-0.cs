    <rx:RoutedViewHost
                Router="{Binding Router, Mode=OneTime}"
                HorizontalContentAlignment="Stretch"
                VerticalContentAlignment="Stretch">
        <rx:RoutedViewHost.Style>
            <Style TargetType="rx:TransitioningContentControl">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="rx:TransitioningContentControl">
                            <Grid 
                            x:Name="PART_Container"
                            VerticalAlignment="{TemplateBinding VerticalAlignment}"
                            HorizontalAlignment="{TemplateBinding HorizontalAlignment}">
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="PresentationStates">
                                        <VisualState x:Name="Normal">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames 
                                                BeginTime="00:00:00" 
                                                Storyboard.TargetName="PART_PreviousContentPresentationSite" 
                                                Storyboard.TargetProperty="(UIElement.Visibility)">
                                                    <DiscreteObjectKeyFrame KeyTime="00:00:00">
                                                        <DiscreteObjectKeyFrame.Value>
                                                            <Visibility>Collapsed</Visibility>
                                                        </DiscreteObjectKeyFrame.Value>
                                                    </DiscreteObjectKeyFrame>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="FadeTransition_OutIn">
                                            <Storyboard>
                                                <DoubleAnimation 
                                                BeginTime="00:00:00" Duration="00:00:00"
                                                Storyboard.TargetName="PART_PreviousContentPresentationSite"
                                                Storyboard.TargetProperty="(UIElement.Opacity)"
                                                From="1" To="0"/>
                                                <DoubleAnimation 
                                                BeginTime="00:00:00" Duration="00:00:00"
                                                Storyboard.TargetName="PART_CurrentContentPresentationSite"
                                                Storyboard.TargetProperty="(UIElement.Opacity)"
                                                From="0" To="1"/>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="FadeDownTransition_OutIn">
                                            <Storyboard>
                                                <DoubleAnimation 
                                                BeginTime="00:00:00" Duration="00:00:00"
                                                Storyboard.TargetName="PART_CurrentContentPresentationSite" 
                                                Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)"
                                                From="-30" To="0"/>
                                                <DoubleAnimation 
                                                BeginTime="00:00:00" Duration="00:00:00"
                                                Storyboard.TargetName="PART_PreviousContentPresentationSite" 
                                                Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)"
                                                From="0" To="30"/>
                                                <DoubleAnimation 
                                                BeginTime="00:00:00" Duration="00:00:00"
                                                Storyboard.TargetName="PART_CurrentContentPresentationSite"
                                                Storyboard.TargetProperty="(UIElement.Opacity)"
                                                From="0" To="1"/>
                                                <DoubleAnimation 
                                                BeginTime="00:00:00" Duration="00:00:00"
                                                Storyboard.TargetName="PART_PreviousContentPresentationSite"
                                                Storyboard.TargetProperty="(UIElement.Opacity)"
                                                From="1" To="0"/>
                                            </Storyboard>
                                        </VisualState>
                                        <!-- SlideLeftTransition -->
                                        <VisualState x:Name="SlideLeftTransition_In">
                                            <Storyboard>
                                                <DoubleAnimationUsingKeyFrames 
                                                Storyboard.TargetName="PART_CurrentContentPresentationSite"
                                                Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)">
                                                    <EasingDoubleKeyFrame KeyTime="00:00:00" Value="-90"/>
                                                    <EasingDoubleKeyFrame KeyTime="00:00:00" Value="-90"/>
                                                    <EasingDoubleKeyFrame KeyTime="00:00:00" Value="0">
                                                        <EasingDoubleKeyFrame.EasingFunction>
                                                            <CircleEase EasingMode="EaseOut"/>
                                                        </EasingDoubleKeyFrame.EasingFunction>
                                                    </EasingDoubleKeyFrame>
                                                </DoubleAnimationUsingKeyFrames>
                                                <DoubleAnimationUsingKeyFrames 
                                                Storyboard.TargetName="PART_CurrentContentPresentationSite" 
                                                Storyboard.TargetProperty="(UIElement.Opacity)">
                                                    <DiscreteDoubleKeyFrame KeyTime="00:00:00" Value="0"/>
                                                    <DiscreteDoubleKeyFrame KeyTime="00:00:00" Value="1"/>
                                                </DoubleAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames 
                                                Storyboard.TargetName="PART_PreviousContentPresentationSite" 
                                                Storyboard.TargetProperty="(UIElement.Visibility)">
                                                    <DiscreteObjectKeyFrame KeyTime="00:00:00">
                                                        <DiscreteObjectKeyFrame.Value>
                                                            <Visibility>Collapsed</Visibility>
                                                        </DiscreteObjectKeyFrame.Value>
                                                    </DiscreteObjectKeyFrame>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="SlideLeftTransition_Out">
                                            <Storyboard>
                                                <DoubleAnimation 
                                                BeginTime="00:00:00" Duration="00:00:00"
                                                Storyboard.TargetName="PART_PreviousContentPresentationSite" 
                                                Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)"
                                                From="0" To="-90"/>
                                                <ObjectAnimationUsingKeyFrames 
                                                Storyboard.TargetName="PART_CurrentContentPresentationSite" 
                                                Storyboard.TargetProperty="(UIElement.Visibility)">
                                                    <DiscreteObjectKeyFrame KeyTime="00:00:00">
                                                        <DiscreteObjectKeyFrame.Value>
                                                            <Visibility>Collapsed</Visibility>
                                                        </DiscreteObjectKeyFrame.Value>
                                                    </DiscreteObjectKeyFrame>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <ContentPresenter 
                                x:Name="PART_PreviousContentPresentationSite"
                                Content="{x:Null}"
                                ContentTemplate="{TemplateBinding ContentTemplate}"
                                HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                VerticalAlignment="{TemplateBinding VerticalContentAlignment}">
                                    <ContentPresenter.RenderTransform>
                                        <TransformGroup>
                                            <TransformGroup.Children>
                                                <ScaleTransform ScaleX="1" ScaleY="1" />
                                                <TranslateTransform X="0" Y="0" />
                                            </TransformGroup.Children>
                                        </TransformGroup>
                                    </ContentPresenter.RenderTransform>
                                </ContentPresenter>
                                <ContentPresenter
                                x:Name="PART_CurrentContentPresentationSite"
                                Content="{x:Null}"
                                ContentTemplate="{TemplateBinding ContentTemplate}"
                                HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                VerticalAlignment="{TemplateBinding VerticalContentAlignment}">
                                    <ContentPresenter.RenderTransform>
                                        <TransformGroup>
                                            <TransformGroup.Children>
                                                <ScaleTransform ScaleX="1" ScaleY="1" />
                                                <TranslateTransform X="0" Y="0" />
                                            </TransformGroup.Children>
                                        </TransformGroup>
                                    </ContentPresenter.RenderTransform>
                                </ContentPresenter>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </rx:RoutedViewHost.Style>
    </rx:RoutedViewHost>
