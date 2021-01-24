    <ControlTemplate TargetType="Button">
            <Grid Background="{TemplateBinding Background}" TextBlock.Foreground="{TemplateBinding Foreground}">
                <Rectangle Fill="White" Opacity="0." x:Name="Overlay" />
                <Rectangle Fill="Gray" Opacity="0." x:Name="OverlayDark" />
                <ContentPresenter Margin="{TemplateBinding Padding}"
                                  VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                  HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" />
                <VisualStateManager.VisualStateGroups>
                    <VisualStateGroup Name="CommonStates">
                        <VisualState Name="Normal">
                            <VisualState.Storyboard>
                                <Storyboard>
                                    <DoubleAnimation To="0.0" Duration="0:0:0.1" Storyboard.TargetName="Overlay"
                                                     Storyboard.TargetProperty="Opacity" />
                                </Storyboard>
                            </VisualState.Storyboard>
                        </VisualState>
                        <VisualState Name="Pressed">
                            <Storyboard>
                                <DoubleAnimation To="0.5" Duration="0:0:0.1" Storyboard.TargetName="OverlayDark"
                                                 Storyboard.TargetProperty="Opacity" />
                            </Storyboard>
                        </VisualState>
                        <VisualState Name="MouseOver">
                            <VisualState.Storyboard>
                                <Storyboard>
                                    <DoubleAnimation To="0.5" Duration="0:0:0.1" Storyboard.TargetName="Overlay"
                                                     Storyboard.TargetProperty="Opacity" />
                                </Storyboard>
                            </VisualState.Storyboard>
                        </VisualState>
                        <VisualState Name="Disabled">
                            <Storyboard>
                                <DoubleAnimation To="1" Duration="0:0:0.1" Storyboard.TargetName="OverlayDark"
                                                 Storyboard.TargetProperty="Opacity" />
                            </Storyboard>
                        </VisualState>
                    </VisualStateGroup>
                </VisualStateManager.VisualStateGroups>
            </Grid>
        </ControlTemplate>
