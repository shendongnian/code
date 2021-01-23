    <ResourceDictionary
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:CarouselPageNavigation.UWP.Controls">
    
        <ResourceDictionary.ThemeDictionaries>
            <ResourceDictionary x:Key="Default">
                <SolidColorBrush x:Key="FlipViewIndicatorUnselectedThemeBrush">Gray</SolidColorBrush>
                <SolidColorBrush x:Key="FlipViewIndicatorSelectedThemeBrush">#FFFFFFFF</SolidColorBrush>
            </ResourceDictionary>
            <ResourceDictionary x:Key="Light">
                <SolidColorBrush x:Key="FlipViewIndicatorUnselectedThemeBrush">Gray</SolidColorBrush>
                <SolidColorBrush x:Key="FlipViewIndicatorSelectedThemeBrush">#FF000000</SolidColorBrush>
            </ResourceDictionary>
            <ResourceDictionary x:Key="HighContrast">
                <SolidColorBrush x:Key="FlipViewIndicatorUnselectedThemeBrush" Color="{ThemeResource SystemColorButtonFaceColor}" />
                <SolidColorBrush x:Key="FlipViewIndicatorSelectedThemeBrush" Color="{ThemeResource SystemColorHighlightColor}" />
            </ResourceDictionary>
        </ResourceDictionary.ThemeDictionaries>
        <Style TargetType="ListBoxItem" x:Key="FlipViewIndicatorItem">
            <Setter Property="Padding" Value="0,4,10,4"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ListBoxItem">
                        <Grid>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="SelectionStates">
                                    <VisualState x:Name="Unselected"/>
                                    <VisualState x:Name="Selected">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Fill" Storyboard.TargetName="PART_FlipViewIndicatorItem">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource FlipViewIndicatorSelectedThemeBrush}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="SelectedUnfocused">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Fill" Storyboard.TargetName="PART_FlipViewIndicatorItem">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource FlipViewIndicatorSelectedThemeBrush}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="SelectedPointerOver">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Fill" Storyboard.TargetName="PART_FlipViewIndicatorItem">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource FlipViewIndicatorSelectedThemeBrush}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <Ellipse x:Name="PART_FlipViewIndicatorItem" 
                                       Width="20" Height="20" Fill="{ThemeResource FlipViewIndicatorUnselectedThemeBrush}" 
                                       Margin="0,5,5,0" />
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    
        <Style TargetType="local:FlipViewIndicator">
            <Setter Property="Margin" Value="3,0,0,0" />
            <Setter Property="ItemContainerStyle" Value="{StaticResource FlipViewIndicatorItem}" />
            <Setter Property="ItemsPanel">
                <Setter.Value>
                    <ItemsPanelTemplate>
                        <StackPanel Orientation="Horizontal" />
                    </ItemsPanelTemplate>
                </Setter.Value>
            </Setter>
            <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Disabled" />
            <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Auto" />
            <Setter Property="ScrollViewer.HorizontalScrollMode" Value="Disabled" />
            <Setter Property="ScrollViewer.IsHorizontalRailEnabled" Value="True" />
            <Setter Property="ScrollViewer.VerticalScrollMode" Value="Enabled" />
            <Setter Property="ScrollViewer.IsVerticalRailEnabled" Value="True" />
            <Setter Property="ScrollViewer.ZoomMode" Value="Disabled" />
            <Setter Property="IsTabStop" Value="False" />
            <Setter Property="TabNavigation" Value="Once" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ListBox">
                        <Border x:Name="PART_FlipViewIndicatorLayoutRoot" 
                                BorderBrush="{TemplateBinding BorderBrush}" 
                                BorderThickness="{TemplateBinding BorderThickness}" 
                                Background="{TemplateBinding Background}">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualState x:Name="Normal"/>
                                    <VisualState x:Name="Disabled">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="PART_FlipViewIndicatorLayoutRoot">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="Transparent"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="PART_FlipViewIndicatorLayoutRoot">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource ListBoxDisabledForegroundThemeBrush}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="FocusStates">
                                    <VisualState x:Name="Focused">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="PART_FlipViewIndicatorLayoutRoot">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource ListBoxFocusBackgroundThemeBrush}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Unfocused"/>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <ScrollViewer x:Name="ScrollViewer" 
                                          HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" 
                                          HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" 
                                          IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" 
                                          IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" 
                                          Padding="{TemplateBinding Padding}" TabNavigation="{TemplateBinding TabNavigation}" 
                                          VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" 
                                          VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" 
                                          ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}">
                                <ItemsPresenter Margin="{TemplateBinding Margin}" />
                            </ScrollViewer>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </ResourceDictionary>
