    <Button x:Name="btn" Content="Hover me"/>
    <TextBlock x:Name="tb" Text="Input">
        <TextBlock.Style>
            <Style TargetType="{x:Type TextBlock}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding ElementName=btn, Path=IsMouseOver}" Value="True">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation
                                        Storyboard.TargetProperty="Opacity"
                                        From="1.0" To="0.0" Duration="0:0:1" 
                                        AutoReverse="true" RepeatBehavior="1x">
                                    </DoubleAnimation>
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.EnterActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </TextBlock.Style>
    </TextBlock>
