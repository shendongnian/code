        <Button x:Name="btnTest">
            <Interactivity:Interaction.Behaviors>
                <Core:EventTriggerBehavior EventName="GotFocus">
                    <Core:EventTriggerBehavior.Actions>
                        <Core:InvokeCommandAction Command="{Binding OnButtonFocusCommand}" />
                    </Core:EventTriggerBehavior.Actions>
                </Core:EventTriggerBehavior>
            </Interactivity:Interaction.Behaviors>
        </Button>
