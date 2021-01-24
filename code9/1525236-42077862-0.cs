    <Page.Resources>
        <Style x:Key="MyTextBoxStyle" TargetType="TextBox">
            <Setter Property="MinWidth" Value="{ThemeResource TextControlThemeMinWidth}"/>
            <Setter Property="MinHeight" Value="{ThemeResource TextControlThemeMinHeight}"/>
            <Setter Property="Foreground" Value="{ThemeResource TextControlForeground}"/>
            <Setter Property="Background" Value="{ThemeResource TextControlBackground}"/>
            <Setter Property="BorderBrush" Value="{ThemeResource TextControlBorderBrush}"/>
            <Setter Property="SelectionHighlightColor" Value="{ThemeResource TextControlSelectionHighlightColor}"/>
            <Setter Property="BorderThickness" Value="{ThemeResource TextControlBorderThemeThickness}"/>
            <Setter Property="FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}"/>
            <Setter Property="FontSize" Value="{ThemeResource ControlContentThemeFontSize}"/>
            <Setter Property="ScrollViewer.HorizontalScrollMode" Value="Auto"/>
            <Setter Property="ScrollViewer.VerticalScrollMode" Value="Auto"/>
            <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Hidden"/>
            <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Hidden"/>
            <Setter Property="ScrollViewer.IsDeferredScrollingEnabled" Value="False"/>
            <Setter Property="Padding" Value="{ThemeResource TextControlThemePadding}"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="TextBox">
                        <Grid>
                            <Grid.Resources>
                                <Style x:Name="DeleteButtonStyle" TargetType="Button">
                                    <Setter Property="Template">
                                        <Setter.Value>
                                            <ControlTemplate TargetType="Button">
                                                <Grid x:Name="ButtonLayoutGrid" BorderBrush="{ThemeResource TextControlButtonBorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{ThemeResource TextControlButtonBackground}">
                                                    <VisualStateManager.VisualStateGroups>
                                                        <VisualStateGroup x:Name="CommonStates">
                                                            <VisualState x:Name="Normal"/>
                                                            <VisualState x:Name="PointerOver">
                                                                <Storyboard>
                                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="ButtonLayoutGrid">
                                                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonBackgroundPointerOver}"/>
                                                                    </ObjectAnimationUsingKeyFrames>
                                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="ButtonLayoutGrid">
                                                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonBorderBrushPointerOver}"/>
                                                                    </ObjectAnimationUsingKeyFrames>
                                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="GlyphElement">
                                                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonForegroundPointerOver}"/>
                                                                    </ObjectAnimationUsingKeyFrames>
                                                                </Storyboard>
                                                            </VisualState>
                                                            <VisualState x:Name="Pressed">
                                                                <Storyboard>
                                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="ButtonLayoutGrid">
                                                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonBackgroundPressed}"/>
                                                                    </ObjectAnimationUsingKeyFrames>
                                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="ButtonLayoutGrid">
                                                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonBorderBrushPressed}"/>
                                                                    </ObjectAnimationUsingKeyFrames>
                                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="GlyphElement">
                                                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlButtonForegroundPressed}"/>
                                                                    </ObjectAnimationUsingKeyFrames>
                                                                </Storyboard>
                                                            </VisualState>
                                                            <VisualState x:Name="Disabled">
                                                                <Storyboard>
                                                                    <DoubleAnimation Duration="0" To="0" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="ButtonLayoutGrid"/>
                                                                </Storyboard>
                                                            </VisualState>
                                                        </VisualStateGroup>
                                                    </VisualStateManager.VisualStateGroups>
                                                    <TextBlock x:Name="GlyphElement" AutomationProperties.AccessibilityView="Raw" Foreground="{ThemeResource TextControlButtonForeground}" FontStyle="Normal" FontSize="12" FontFamily="{ThemeResource SymbolThemeFontFamily}" HorizontalAlignment="Center" Text="&#xE10A;" VerticalAlignment="Center"/>
                                                </Grid>
                                            </ControlTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </Style>
                            </Grid.Resources>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="*"/>
                                <ColumnDefinition Width="Auto"/>
                            </Grid.ColumnDefinitions>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="Auto"/>
                                <RowDefinition Height="*"/>
                            </Grid.RowDefinitions>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualState x:Name="Disabled">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="HeaderContentPresenter">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlHeaderForegroundDisabled}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="BorderElement">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBackgroundDisabled}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="BorderElement">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBorderBrushDisabled}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="ContentElement">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlForegroundDisabled}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="PlaceholderTextContentPresenter">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlPlaceholderForegroundDisabled}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Normal"/>
                                    <VisualState x:Name="PointerOver">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="BorderElement">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBorderBrushPointerOver}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="BorderElement">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBackgroundPointerOver}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="PlaceholderTextContentPresenter">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlPlaceholderForegroundPointerOver}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="ContentElement">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlForegroundPointerOver}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Focused">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="PlaceholderTextContentPresenter">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlPlaceholderForegroundFocused}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="BorderElement">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBackgroundFocused}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="BorderElement">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlBorderBrushFocused}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Foreground" Storyboard.TargetName="ContentElement">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource TextControlForegroundFocused}"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="RequestedTheme" Storyboard.TargetName="ContentElement">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="Light"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="ShadowOpacity" Storyboard.TargetName="Shadow">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="0.7"/>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="ButtonStates">
                                    <VisualState x:Name="ButtonVisible">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="DeleteButton">
                                                <DiscreteObjectKeyFrame KeyTime="0">
                                                    <DiscreteObjectKeyFrame.Value>
                                                        <Visibility>Visible</Visibility>
                                                    </DiscreteObjectKeyFrame.Value>
                                                </DiscreteObjectKeyFrame>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="ButtonCollapsed"/>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <controls:DropShadowPanel x:Name="Shadow" BlurRadius="8" OffsetX="0" OffsetY="0" ShadowOpacity="0" Color="Black" Grid.ColumnSpan="2" Grid.Row="1" Grid.RowSpan="1">
                                <Border x:Name="BorderElement" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" CornerRadius="5"/>
                            </controls:DropShadowPanel>
                            <ContentPresenter x:Name="HeaderContentPresenter" Grid.ColumnSpan="2" ContentTemplate="{TemplateBinding HeaderTemplate}" Content="{TemplateBinding Header}" Foreground="{ThemeResource TextControlHeaderForeground}" FontWeight="Normal" Margin="0,0,0,8" Grid.Row="0" Visibility="Collapsed" x:DeferLoadStrategy="Lazy"/>
                            <ScrollViewer x:Name="ContentElement" AutomationProperties.AccessibilityView="Raw" HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" IsTabStop="False" IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" Margin="{TemplateBinding BorderThickness}" Padding="{TemplateBinding Padding}" Grid.Row="1" VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" ZoomMode="Disabled"/>
                            <ContentControl x:Name="PlaceholderTextContentPresenter" Grid.ColumnSpan="2" Content="{TemplateBinding PlaceholderText}" Foreground="{ThemeResource TextControlPlaceholderForeground}" IsHitTestVisible="False" IsTabStop="False" Margin="{TemplateBinding BorderThickness}" Padding="{TemplateBinding Padding}" Grid.Row="1"/>
                            <Button x:Name="DeleteButton" AutomationProperties.AccessibilityView="Raw" BorderThickness="{TemplateBinding BorderThickness}" Grid.Column="1" FontSize="{TemplateBinding FontSize}" IsTabStop="False" Margin="{ThemeResource HelperButtonThemePadding}" MinWidth="34" Grid.Row="1" Style="{StaticResource DeleteButtonStyle}" Visibility="Collapsed" VerticalAlignment="Stretch"/>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Page.Resources>
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <TextBox Width="100" Margin="50" Height="30" Style="{StaticResource MyTextBoxStyle}" HorizontalAlignment="Left"/>
        <TextBox Width="100" Margin="50,100,0,0" Height="30" Style="{StaticResource MyTextBoxStyle}" HorizontalAlignment="Left"/>
    </Grid>
