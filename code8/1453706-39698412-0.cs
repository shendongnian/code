    <Style x:Key="GVCHWithIcon" TargetType="GridViewColumnHeader">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="GridViewColumnHeader">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="25"/>                                   
                            <ColumnDefinition Width="100"/>
                        </Grid.ColumnDefinitions>
                        <Image Source="..." />
                        <TextBlock Text="DATE" Grid.Column="1"/>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
