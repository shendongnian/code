    <Button Height="50" Width="50">
        <Image Source="Images/ok_icon.png">
            <Image.RenderTransform>
                <RotateTransform CenterX="25" CenterY="25"/>
            </Image.RenderTransform>
            <Image.Style>
                <Style TargetType="Image">
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Trigger.EnterActions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimation 
                                                     Storyboard.TargetProperty="(Image.RenderTransform).(RotateTransform.Angle)"
                                                     From="0"
                                                     To="45"
                                                     Duration="0:0:0.5"
                                                     FillBehavior="Stop"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </Trigger.EnterActions>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </Image.Style>
        </Image>
    </Button>
