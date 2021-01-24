    <Grid>
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup x:Name="ConnectionStatus">
                <VisualState x:Name="Connected">
                    <VisualState.Setters>
                        <Setter Target="button.(Control.IsEnabled)" Value="False"/>
                    </VisualState.Setters>
                </VisualState>
                <VisualState x:Name="NotConnected">
                    <VisualState.Setters>
                        <Setter Target="button.(Control.IsEnabled)" Value="True"/>
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>
        <Interactivity:Interaction.Behaviors>
            <Core:DataTriggerBehavior Binding="{Binding VsmConnectionStatus}" 
                                          Value="{Binding VsmConnectionStatus}">
                <Core:GoToStateAction StateName="{Binding VsmConnectionStatus}"/>
            </Core:DataTriggerBehavior>
        </Interactivity:Interaction.Behaviors>
        <Button Content="{Binding VsmConnectionStatus}" x:Name="button">
        </Button>
    </Grid>
