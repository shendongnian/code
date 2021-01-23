    <Grid Background="#363636">
            <Grid.Resources>
                <Storyboard x:Key="OnMouseEnter">
                    <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="Background.Color" >
                        <DiscreteColorKeyFrame KeyTime="0" Value="#555555"></DiscreteColorKeyFrame>
                    </ColorAnimationUsingKeyFrames>
                </Storyboard>
            </Grid.Resources>
            <Grid.Triggers>
                <EventTrigger RoutedEvent="UIElement.MouseEnter">
                    <BeginStoryboard Storyboard="{StaticResource OnMouseEnter}"/>
                </EventTrigger>
            </Grid.Triggers>
    </Grid>
