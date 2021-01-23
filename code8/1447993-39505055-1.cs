                <Button.Template>
                <ControlTemplate TargetType="Button">
                    
                    <Border BorderThickness="1"
                            x:Name="MBorder"
                            BorderBrush="Black"
                            CornerRadius="10"
                            Padding="4">
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CommonStates">
                                <VisualState x:Name="Normal">
                                    <VisualState.Setters>
                                        <Setter Target="MGrid.Background" Value="#FFB8B1B1"/>
                                        <Setter Target="MBorder.Background" Value="#FFB8B1B1"/>
                                    </VisualState.Setters>
                                </VisualState>
                                
                                <VisualState x:Name="PointerOver">
                                    <VisualState.Setters>
                                        <Setter Target="MGrid.Background" Value="Green"/>
                                        <Setter Target="MBorder.Background" Value="Green"/>
                                    </VisualState.Setters>
                                </VisualState>
                                <VisualState x:Name="Pressed">
                                    <VisualState.Setters>
                                        <Setter Target="MGrid.Background" Value="Blue"/>
                                        <Setter Target="MBorder.Background" Value="Blue"/>
                                    </VisualState.Setters>
                                </VisualState>
                                <VisualState x:Name="Disabled"/>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <Grid x:Name="MGrid">
                            <ContentControl Content="{TemplateBinding Content}"
                                            VerticalContentAlignment="Center"
                                            HorizontalAlignment="Center"
                                            FontSize="{TemplateBinding FontSize}"
                                            Foreground="{TemplateBinding Foreground}"/>
                        </Grid>
                    </Border>
                </ControlTemplate>
            </Button.Template>
            
        </Button>        
        
