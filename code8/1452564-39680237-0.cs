    <Border BorderThickness="3" BorderBrush="#FF341A1A" Height="200">            
            <Border.Background>
            <VisualBrush>
                <VisualBrush.Visual>
                    <Grid>
                        <Image x:Name="Img1" Visibility="Collapsed" Source="{Binding Text, ElementName=MyControl1}"/>
                        <Image x:Name="Img2" Visibility="Collapsed" Source="{Binding Text, ElementName=MyControl2}"/>
                    </Grid>
                </VisualBrush.Visual>
            </VisualBrush>
        </Border.Background>
        <Border.Triggers>
            <EventTrigger RoutedEvent="Border.Loaded">
                <BeginStoryboard>
                    <Storyboard>
                        <ObjectAnimationUsingKeyFrames 
                                    Duration="0:0:3"
                                    Storyboard.TargetName="Img1"
                                    Storyboard.TargetProperty="Visibility"
                                    >
                            <DiscreteObjectKeyFrame KeyTime="0:0:1">
                                <DiscreteObjectKeyFrame.Value>
                                    <Visibility>Visible</Visibility>
                                </DiscreteObjectKeyFrame.Value>
                            </DiscreteObjectKeyFrame>                                
                        </ObjectAnimationUsingKeyFrames>                            
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </Border.Triggers>
    </Border>
