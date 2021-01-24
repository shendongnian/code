    <Style TargetType="Button">      
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="Button">
                            <Grid x:Name="buttonRoot">
                                <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates" />
                                <VisualStateGroup x:Name="FocusStates" />
                                <VisualStateGroup x:Name="AdaptiveGroups">
                                        <VisualState x:Name="narrow" />
                                        <VisualState x:Name="wide">
                                            <VisualState.StateTriggers>
                                                <AdaptiveTrigger MinWindowWidth="800" />
                                            </VisualState.StateTriggers>
                                            <VisualState.Setters>
                                                <Setter Target="buttonRoot.Width" Value="200" />
                                                <Setter Target="buttonRoot.Height" Value="200" />
                                            </VisualState.Setters>
                                        </VisualState>
                                    </VisualStateGroup>
                                    
                                </VisualStateManager.VisualStateGroups>
                         
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
