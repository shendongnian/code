    <DataTemplate>
        <Grid>
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="Click">
                    <i:InvokeCommandAction Command="{Binding Path=DataContext.YourClickCommand, ElementNameYourControlsName}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
       </Grid>
    </DataTemplate>
