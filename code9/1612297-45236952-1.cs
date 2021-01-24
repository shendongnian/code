        <Rectangle Margin="5,0" HorizontalAlignment="Left"  Width="380" Height="25" Fill="LightYellow" 
                       Stroke="Orange" StrokeThickness="2" RadiusX="8" RadiusY="8">
        <Rectangle.Style>
            <Style TargetType="Rectangle">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding StartBlinking}" Value="True">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation Storyboard.TargetProperty="Stroke.(SolidColorBrush.Opacity)" 
                                                             To="0" AutoReverse="True" Duration="0:0:0.5" RepeatBehavior="6x" />
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.EnterActions>
                        <DataTrigger.ExitActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation Storyboard.TargetProperty="Stroke.(SolidColorBrush.Opacity)" 
                                                             To="1" Duration="0:0:0.5" />
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.ExitActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Rectangle.Style>
    </Rectangle>
