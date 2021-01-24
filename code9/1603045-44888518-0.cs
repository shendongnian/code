            <Grid>
                <Grid.Resources>
                    <Style x:Key="alternatingStyle" TargetType="ListViewItem">
                        <Style.Setters>
                            <Setter Property="IsSelected" Value="{Binding IsSelected}"/>
                            <EventSetter Event="PreviewMouseLeftButtonDown" Handler="lvi_MouseDown" />
                            <EventSetter Event="PreviewMouseMove"  Handler="lvi_MouseMove" />
                        </Style.Setters>
                        <Style.Triggers>
                            <Trigger Property="ItemsControl.AlternationIndex"  Value="0">
                                <Setter Property="Background" Value="LightBlue" />
                            </Trigger>
                            <Trigger Property="ItemsControl.AlternationIndex"  Value="1">
                                <Setter Property="Background" Value="LightGray" />
                            </Trigger>
                            <Trigger Property="IsSelected" Value="True">
                                <Setter Property="Background" Value="Orange"/>
                            </Trigger>
                        </Style.Triggers>                        
                    </Style>
                </Grid.Resources>
                <ListView ItemContainerStyle="{StaticResource alternatingStyle}"
                          AlternationCount="2">
                </ListView>
