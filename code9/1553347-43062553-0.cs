     <Style TargetType="PivotHeaderItem">
                <Setter Property="FontSize" Value="{ThemeResource PivotHeaderItemFontSize}" />
                <Setter Property="FontFamily" Value="{ThemeResource PivotHeaderItemFontFamily}" />
                <Setter Property="FontWeight" Value="{ThemeResource PivotHeaderItemThemeFontWeight}" />
                <Setter Property="CharacterSpacing" Value="{ThemeResource PivotHeaderItemCharacterSpacing}" />
                <Setter Property="Background" Value="Transparent" />
                <Setter Property="Foreground" Value="{ThemeResource SystemControlForegroundBaseMediumBrush}" />
                <Setter Property="Padding" Value="{ThemeResource PivotHeaderItemMargin}" />
                <Setter Property="Height" Value="48" />
                <Setter Property="VerticalContentAlignment" Value="Center" />
                <Setter Property="IsTabStop" Value="False" />
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="PivotHeaderItem">
                            <Grid
                                  x:Name="Grid"
                                  Background="{TemplateBinding Background}">
                               
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="SelectionStates">
                                        <VisualStateGroup.Transitions>
                                            <VisualTransition From="Unselected" To="UnselectedLocked" GeneratedDuration="0:0:0.33" />
                                            <VisualTransition From="UnselectedLocked" To="Unselected" GeneratedDuration="0:0:0.33" />
                                        </VisualStateGroup.Transitions>
                                        <VisualState x:Name="Disabled">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentPresenter"
                                                   Storyboard.TargetProperty="Foreground" >
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlDisabledBaseMediumLowBrush}" />
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Unselected" />
                                        <VisualState x:Name="UnselectedLocked">
                                            <Storyboard>
                                                <DoubleAnimation Storyboard.TargetName="ContentPresenterTranslateTransform"
                                     Storyboard.TargetProperty="X"
                                     Duration="0" To="{ThemeResource PivotHeaderItemLockedTranslation}" />
                                                <DoubleAnimation Storyboard.TargetName="ContentPresenter"
                                     Storyboard.TargetProperty="(UIElement.Opacity)"
                                     Duration="0" To="0" />
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Selected">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentPresenter"
                                                   Storyboard.TargetProperty="Foreground" >
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltBaseHighBrush}" />
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="Grid"
                                                   Storyboard.TargetProperty="Background" >
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightTransparentBrush}" />
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="UnselectedPointerOver">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentPresenter"
                                                   Storyboard.TargetProperty="Foreground" >
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltBaseMediumHighBrush}" />
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="Grid"
                                                   Storyboard.TargetProperty="Background" >
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightTransparentBrush}" />
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="SelectedPointerOver">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentPresenter"
                                                    Storyboard.TargetProperty="Foreground" >
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltBaseMediumHighBrush}" />
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="Grid"
                                                   Storyboard.TargetProperty="Background" >
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightTransparentBrush}" />
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="UnselectedPressed">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentPresenter"
                                                   Storyboard.TargetProperty="Foreground" >
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltBaseMediumHighBrush}" />
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="Grid"
                                                   Storyboard.TargetProperty="Background" >
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightTransparentBrush}" />
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="SelectedPressed">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentPresenter"
                                                   Storyboard.TargetProperty="Foreground" >
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltBaseMediumHighBrush}" />
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="Grid"
                                                   Storyboard.TargetProperty="Background" >
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightTransparentBrush}" />
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="WindowStates">
                                        <VisualState x:Name="WideState">
                                            <VisualState.StateTriggers>
                                                <AdaptiveTrigger MinWindowWidth="800" />
                                            </VisualState.StateTriggers>
                                            <VisualState.Setters>
                                                <Setter Target="ContentPresenter.Background" Value="LightYellow" />
                                            </VisualState.Setters>
                                        </VisualState>
                                        <VisualState x:Name="NarrowState">
                                            <VisualState.StateTriggers>
                                                <AdaptiveTrigger MinWindowWidth="0" />
                                            </VisualState.StateTriggers>
                                            <VisualState.Setters>
                                                <Setter   Target="ContentPresenter.Background" Value="LightGreen" />
                                            </VisualState.Setters>
                                        </VisualState>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <ContentPresenter
                x:Name="ContentPresenter"
                Content="{TemplateBinding Content}"
                ContentTemplate="{TemplateBinding ContentTemplate}"
                Margin="{TemplateBinding Padding}"
                FontSize="{TemplateBinding FontSize}"
                FontFamily="{TemplateBinding FontFamily}"
                FontWeight="{TemplateBinding FontWeight}"
                HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                VerticalAlignment="{TemplateBinding VerticalContentAlignment}">
                                    <ContentPresenter.RenderTransform>
                                        <TranslateTransform x:Name="ContentPresenterTranslateTransform" />
                                    </ContentPresenter.RenderTransform>
                                </ContentPresenter>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
