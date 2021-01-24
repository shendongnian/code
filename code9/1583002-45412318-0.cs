    <Style x:Name="ComboBoxWithoutCircularScroll" TargetType="ComboBox">
        <Setter Property="ItemsPanel">
            <Setter.Value>
                <ItemsPanelTemplate>
                    <StackPanel/>
                </ItemsPanelTemplate>
            </Setter.Value>
        </Setter>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ComboBox">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*"/>
                            <ColumnDefinition Width="32"/>
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CommonStates">
                                <VisualState x:Name="Normal"/>
                                <VisualState x:Name="PointerOver">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="Background">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlPageBackgroundAltMediumBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="Background">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightBaseMediumBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Pressed">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="Background">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlBackgroundListMediumBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="Background">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightBaseMediumLowBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Disabled">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="Background">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlBackgroundBaseLowBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="Background">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlDisabledBaseLowBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="HeaderContentPresenter">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlDisabledBaseMediumLowBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="ContentPresenter">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlDisabledBaseMediumLowBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="PlaceholderTextBlock">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlDisabledBaseMediumLowBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="DropDownGlyph">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlDisabledBaseMediumLowBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="FocusStates">
                                <VisualState x:Name="Focused">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="HighlightBackground">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightTransparentBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="HighlightBackground"/>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="ContentPresenter">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltBaseHighBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="PlaceholderTextBlock">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltBaseHighBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="DropDownGlyph">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltBaseMediumHighBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="FocusedPressed">
                                    <Storyboard>
                                        <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="HighlightBackground"/>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="ContentPresenter">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltBaseHighBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="PlaceholderTextBlock">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltBaseHighBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="DropDownGlyph">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlHighlightAltBaseMediumHighBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Unfocused"/>
                                <VisualState x:Name="PointerFocused"/>
                                <VisualState x:Name="FocusedDropDown">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Duration="0" Storyboard.TargetProperty="Visibility" Storyboard.TargetName="PopupBorder">
                                            <DiscreteObjectKeyFrame KeyTime="0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <Visibility>Visible</Visibility>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="DropDownStates">
                                <VisualState x:Name="Opened">
                                    <Storyboard>
                                        <SplitOpenThemeAnimation ClosedTargetName="ContentPresenter" OffsetFromCenter="{Binding TemplateSettings.DropDownOffset, RelativeSource={RelativeSource Mode=TemplatedParent}}" OpenedTargetName="PopupBorder" OpenedLength="{Binding TemplateSettings.DropDownOpenedHeight, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Closed">
                                    <Storyboard>
                                        <SplitCloseThemeAnimation ClosedTargetName="ContentPresenter" OffsetFromCenter="{Binding TemplateSettings.DropDownOffset, RelativeSource={RelativeSource Mode=TemplatedParent}}" OpenedTargetName="PopupBorder" OpenedLength="{Binding TemplateSettings.DropDownOpenedHeight, RelativeSource={RelativeSource Mode=TemplatedParent}}"/>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <ContentPresenter x:Name="HeaderContentPresenter" ContentTemplate="{TemplateBinding HeaderTemplate}" Content="{TemplateBinding Header}" FontWeight="{ThemeResource ComboBoxHeaderThemeFontWeight}" FlowDirection="{TemplateBinding FlowDirection}" Margin="{ThemeResource ComboBoxHeaderThemeMargin}" Visibility="Collapsed" x:DeferLoadStrategy="Lazy"/>
                        <Border x:Name="Background" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Grid.ColumnSpan="2" Grid.Row="1"/>
                        <Border x:Name="HighlightBackground" BorderBrush="{ThemeResource SystemControlHighlightBaseMediumLowBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{ThemeResource SystemControlHighlightListAccentLowBrush}" Grid.ColumnSpan="2" Opacity="0" Grid.Row="1"/>
                        <ContentPresenter x:Name="ContentPresenter" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" Grid.Row="1" VerticalAlignment="{TemplateBinding VerticalContentAlignment}">
                            <TextBlock x:Name="PlaceholderTextBlock" Foreground="{ThemeResource SystemControlPageTextBaseHighBrush}" Text="{TemplateBinding PlaceholderText}"/>
                        </ContentPresenter>
                        <FontIcon x:Name="DropDownGlyph" AutomationProperties.AccessibilityView="Raw" Grid.Column="1" Foreground="{ThemeResource SystemControlForegroundBaseMediumHighBrush}" FontSize="12" FontFamily="{ThemeResource SymbolThemeFontFamily}" Glyph="&#xE0E5;" HorizontalAlignment="Right" IsHitTestVisible="False" Margin="0,10,10,10" Grid.Row="1" VerticalAlignment="Center"/>
                        <Popup x:Name="Popup">
                            <Border x:Name="PopupBorder" BorderBrush="{ThemeResource SystemControlForegroundChromeHighBrush}" BorderThickness="{ThemeResource ComboBoxDropdownBorderThickness}" Background="{ThemeResource SystemControlBackgroundChromeMediumLowBrush}" HorizontalAlignment="Stretch" Margin="0,-1,0,-1">
                                <ScrollViewer x:Name="ScrollViewer" AutomationProperties.AccessibilityView="Raw" BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}" Foreground="{ThemeResource SystemControlForegroundBaseHighBrush}" HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" MinWidth="{Binding TemplateSettings.DropDownContentMinWidth, RelativeSource={RelativeSource Mode=TemplatedParent}}" VerticalSnapPointsType="None" VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" VerticalSnapPointsAlignment="Near" ZoomMode="Disabled">
                                    <ItemsPresenter Margin="{ThemeResource ComboBoxDropdownContentMargin}"/>
                                </ScrollViewer>
                            </Border>
                        </Popup>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
