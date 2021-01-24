    <Grid>
        <Rectangle Fill="Gray">
            <Rectangle.Style>
                <Style TargetType="Rectangle">
                    <Style.Triggers>
                        <EventTrigger RoutedEvent="Loaded">
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation To="0" Duration="0:0:1"
                                        Storyboard.TargetProperty="RenderTransform.X"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </Style.Triggers>
                </Style>
            </Rectangle.Style>
            <Rectangle.RenderTransform>
                <TranslateTransform X="{Binding ActualWidth,
                                    RelativeSource={RelativeSource AncestorType=Rectangle}}"/>
            </Rectangle.RenderTransform>
        </Rectangle>
    </Grid>
