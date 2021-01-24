    <DataTemplate>
        <Grid>
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="Click">
                    <i:InvokeCommandAction Command="{Binding Path=DataContext.YourClickCommand, ElementName=<Name of the element e.g. ListBox>}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
       </Grid>
    </DataTemplate>
