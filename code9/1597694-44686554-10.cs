        <Slider
            TickPlacement="Both"
            TickFrequency="0.5"
            BorderBrush="Red"
            BorderThickness="3" >
            <Slider.Template>
                <ControlTemplate TargetType="Slider">
                    <Border
                        BorderBrush="{TemplateBinding BorderBrush}"
                        BorderThickness="{TemplateBinding BorderThickness}">
                        <Grid>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="Auto" />
                                <RowDefinition />
                            </Grid.RowDefinitions>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition />
                                <ColumnDefinition />
                            </Grid.ColumnDefinitions>
    
                            <TextBlock Text="Left label" Grid.Column="0" Grid.Row="0" />
                            <TextBlock Text="Right label" Grid.Column="1" Grid.Row="0" HorizontalAlignment="Right" />
                            <Slider Grid.Column="0" Grid.ColumnSpan="2" Grid.Row="1"
                                BorderThickness="0"
                                Value="{TemplateBinding Value}"
                                TickFrequency="{TemplateBinding TickFrequency}
                                TickPlacement="{TemplateBinding TickPlacement}"
                                ...
                            />
                        </Grid>
                    </Border>
                </ControlTemplate>
            </Slider.Template>
        </Slider>
