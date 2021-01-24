    <charting:Chart
        x:Name="Chart"
        Width="500"
        Margin="5"
        HorizontalAlignment="Center">
        <charting:ColumnSeries
            Title="Chart Name"
            DependentValuePath="value"
            IndependentValuePath="months">
            <charting:ColumnSeries.DataPointStyle>
                <Style TargetType="charting:ColumnDataPoint">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="charting:ColumnDataPoint">
                                <Border
                                    x:Name="Root"
                                    Width="20"
                                    BorderBrush="{TemplateBinding BorderBrush}"
                                    BorderThickness="{TemplateBinding BorderThickness}"
                                    Opacity="0">
                                    <Grid Background="{TemplateBinding Background}">
                                        <Rectangle
                                            x:Name="SelectionHighlight"
                                            Width="20"
                                            Fill="Red"
                                            Opacity="0" />
                                        <Rectangle
                                            x:Name="MouseOverHighlight"
                                            Width="20"
                                            Fill="White"
                                            Opacity="0" />
                                    </Grid>
                                    <ToolTipService.ToolTip>
                                        <ContentControl Content="{TemplateBinding FormattedDependentValue}" />
                                    </ToolTipService.ToolTip>
                                    <VisualStateManager.VisualStateGroups>
                                        <VisualStateGroup x:Name="CommonStates">
                                            <VisualStateGroup.Transitions>
                                                <VisualTransition GeneratedDuration="0:0:0.1" />
                                            </VisualStateGroup.Transitions>
                                            <VisualState x:Name="Normal" />
                                            <VisualState x:Name="MouseOver">
                                                <Storyboard>
                                                    <DoubleAnimation
                                                        Duration="0"
                                                        Storyboard.TargetName="MouseOverHighlight"
                                                        Storyboard.TargetProperty="Opacity"
                                                        To="0.6" />
                                                </Storyboard>
                                            </VisualState>
                                        </VisualStateGroup>
                                        <VisualStateGroup x:Name="SelectionStates">
                                            <VisualStateGroup.Transitions>
                                                <VisualTransition GeneratedDuration="0:0:0.1" />
                                            </VisualStateGroup.Transitions>
                                            <VisualState x:Name="Unselected" />
                                            <VisualState x:Name="Selected">
                                                <Storyboard>
                                                    <DoubleAnimation
                                                        Duration="0"
                                                        Storyboard.TargetName="SelectionHighlight"
                                                        Storyboard.TargetProperty="Opacity"
                                                        To="0.6" />
                                                </Storyboard>
                                            </VisualState>
                                        </VisualStateGroup>
                                        <VisualStateGroup x:Name="RevealStates">
                                            <VisualStateGroup.Transitions>
                                                <VisualTransition GeneratedDuration="0:0:0.001" />
                                            </VisualStateGroup.Transitions>
                                            <VisualState x:Name="Shown">
                                                <Storyboard>
                                                    <DoubleAnimation
                                                        Duration="0"
                                                        Storyboard.TargetName="Root"
                                                        Storyboard.TargetProperty="Opacity"
                                                        To="1" />
                                                </Storyboard>
                                            </VisualState>
                                            <VisualState x:Name="Hidden">
                                                <Storyboard>
                                                    <DoubleAnimation
                                                        Duration="0"
                                                        Storyboard.TargetName="Root"
                                                        Storyboard.TargetProperty="Opacity"
                                                        To="0" />
                                                </Storyboard>
                                            </VisualState>
                                        </VisualStateGroup>
                                    </VisualStateManager.VisualStateGroups>
                                </Border>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </charting:ColumnSeries.DataPointStyle>
        </charting:ColumnSeries>
    </charting:Chart>
