    <Grid Background="Yellow" Width="50" Height="50">
            <Grid.Resources>
                <Storyboard x:Key="sb">
                    <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen">
                        <DiscreteBooleanKeyFrame KeyTime="0" Value="False" />
                    </BooleanAnimationUsingKeyFrames>
                </Storyboard>
            </Grid.Resources>
            <Grid.ContextMenu>
                <ContextMenu x:Name="contextMenu">
                    <MenuItem>
                        <MenuItem.Header>
                            <Button Content="Settings" x:Name="settingsButton" />
                        </MenuItem.Header>
                    </MenuItem>
                    <MenuItem>
                        <MenuItem.Header>
                            <Button Content="About" />
                        </MenuItem.Header>
                    </MenuItem>
                    <ContextMenu.Triggers>
                        <EventTrigger RoutedEvent="ButtonBase.Click" SourceName="settingsButton">
                            <BeginStoryboard Storyboard="{StaticResource sb}" />
                        </EventTrigger>
                    </ContextMenu.Triggers>
                </ContextMenu>
            </Grid.ContextMenu>
     </Grid>
