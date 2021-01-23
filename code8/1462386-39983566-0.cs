    <Button x:Name="ExpandButton" Background="Transparent" Click="ContextMenu_Click" BorderThickness="0" VerticalAlignment="Center" ContextMenuService.IsEnabled="false">
        <Button.Style>
            <Style TargetType="{x:Type Button}">
                <Style.Triggers>
                    <EventTrigger RoutedEvent="Click">
                        <EventTrigger.Actions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="ContextMenu.IsOpen">
                                        <DiscreteBooleanKeyFrame KeyTime="0:0:0" Value="True"/>
                                    </BooleanAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger.Actions>
                    </EventTrigger>
                </Style.Triggers>
                <Setter Property="ContextMenu">
                    <Setter.Value>
                        <ContextMenu x:Name="popup" MenuItem.Click="menuItem_Click">
                            <MenuItem  Header="Open" cal:Message.Attach="[Click] = [Open($this)]"></MenuItem>
                        </ContextMenu>
                    </Setter.Value>
                </Setter>
            </Style>
        </Button.Style>
        <ContentControl ContentTemplate="{StaticResource Icons.ArrowUp}" Width="10" Height="10" Margin="2" VerticalAlignment="Center"/>
    </Button>
