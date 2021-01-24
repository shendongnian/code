    <DataTemplate>
        <Grid>
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="Click">
                    <i:InvokeCommandAction Command="{Binding YourClickCommand}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
       </Grid>
    </DataTemplate>
