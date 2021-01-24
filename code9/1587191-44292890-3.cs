    <ListBox
        >
        <ListBox.ItemContainerStyle>
            <Style 
                TargetType="ListBoxItem" 
                BasedOn="{StaticResource {x:Type ListBoxItem}}"
                >
                <Style.Setters>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListBoxItem">
                                <Grid
                                    Background="{TemplateBinding Background}"
                                    >
                                    <ContentPresenter />
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style.Setters>
                <Style.Triggers>
                    <Trigger Property="IsSelected" Value="True">
                        <Setter 
                            Property="Background" 
                            Value="{StaticResource {x:Static SystemColors.HighlightBrushKey}}" 
                            />
                        <Setter 
                            Property="Foreground" 
                            Value="{StaticResource {x:Static SystemColors.HighlightTextBrushKey}}" 
                            />
                    </Trigger>
                    <MultiTrigger>
                        <MultiTrigger.Conditions>
                            <Condition Property="IsSelected" Value="True" />
                            <Condition Property="IsEnabled" Value="False" />
                        </MultiTrigger.Conditions>
                        <Setter 
                            Property="Background" 
                            Value="{StaticResource {x:Static SystemColors.InactiveCaptionBrushKey}}" 
                            />
                    </MultiTrigger>
                </Style.Triggers>
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
