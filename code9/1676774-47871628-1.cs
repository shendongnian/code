                <Border.Style>
                    <Style TargetType="{x:Type Border}">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding Path = PanelOpened}" Value="True">
                                <DataTrigger.EnterActions>
                                    <BeginStoryboard >
                                        <Storyboard SpeedRatio="12" TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)">
                                            <DoubleAnimation
                                                Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)"
                                                Duration="0:0:005" From="0" To="-700" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </DataTrigger.EnterActions>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </Border.Style>
