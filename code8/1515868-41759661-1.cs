    <Grid>
        <Grid.Style>
            <Style TargetType="Grid">
                <Setter Property="Visibility" Value="Collapsed"/>
                <Style.Triggers>
                    <MultiDataTrigger>
                        <MultiDataTrigger.Conditions>
                            <Condition Binding="{Binding PasteTags}" Value="True"/>
                            <Condition Binding="{Binding PasteDimensions}" Value="True"/>
                        </MultiDataTrigger.Conditions>
                        <Setter Property="Visibility" Value="Visible"/>
                    </MultiDataTrigger>
                </Style.Triggers>
            </Style>
        </Grid.Style>
    </Grid>
