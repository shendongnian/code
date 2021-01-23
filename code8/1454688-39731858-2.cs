    <Grid Background="Gray">
        <Grid.Triggers>
            <EventTrigger RoutedEvent="MouseDown">
                <BeginStoryboard>
                    <Storyboard>
                        <ObjectAnimationUsingKeyFrames BeginTime="0:0:0.0"  Storyboard.TargetProperty="Visibility" Storyboard.TargetName="MuzzleFlash">
                            <DiscreteObjectKeyFrame Value="{x:Static Visibility.Visible}" />
                            <DiscreteObjectKeyFrame KeyTime="0:0:0.5" Value="{x:Static Visibility.Hidden}" />
                        </ObjectAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Grid.Triggers>
        <Rectangle x:Name="MuzzleFlash" Height="100" Width="100" Fill="Red">
    
        </Rectangle>
    </Grid>
