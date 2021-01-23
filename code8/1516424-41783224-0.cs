     <Slider   Minimum="0" Maximum="10" Value="3">
            <Slider.Template>
                <ControlTemplate   TargetType="Slider" >
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="Auto" MinHeight="{TemplateBinding MinHeight}" />
                            <RowDefinition Height="Auto" />
                        </Grid.RowDefinitions>
                        <Track Grid.Row="1" x:Name="PART_Track">
                            <Track.DecreaseRepeatButton>
                                <RepeatButton   Command="Slider.DecreaseLarge" />
                            </Track.DecreaseRepeatButton>
                            <Track.Thumb>
                                <Thumb>
                                    <Thumb.Template>
                                        <ControlTemplate TargetType="Thumb">
                                            <Ellipse Height="50" Width="50">
                                                <Ellipse.Fill>
                                                    <ImageBrush ImageSource="other.png"/>
                                                </Ellipse.Fill>
                                            </Ellipse>
                                        </ControlTemplate>
                                    </Thumb.Template>
                                </Thumb>
                            </Track.Thumb>
                            <Track.IncreaseRepeatButton>
                                <RepeatButton  Command="Slider.IncreaseLarge" />
                            </Track.IncreaseRepeatButton>
                        </Track>
                    </Grid>
                </ControlTemplate>
            </Slider.Template>
        </Slider>
