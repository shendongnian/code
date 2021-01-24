    <ItemsControl>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Button x:Name="buttonName"/>
                    <Popup PlacementTarget="{Binding ElementName=buttonName}" IsOpen="{Binding IsMouseOver, ElementName=buttonName, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" />
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
