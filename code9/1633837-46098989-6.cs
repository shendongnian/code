    <DataTemplate>
        <Grid Background="Transparent">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="MouseDown">
                    <i:InvokeCommandAction Command="{Binding Path=DataContext.YourClickCommand, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type YourControl}}}" />
                </i:EventTrigger>
            </i:Interaction.Triggers>
            <Label Content="{...}" />
            <Label Content="{...}" />
            <Label Content="{...}" /> 
        </Grid>
    </DataTemplate>
