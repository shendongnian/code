    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition>
                <ColumnDefinition.Style>
                    <Style TargetType="ColumnDefinition">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding ShowAdvanced}" Value="False">
                                <Setter Property="Width" Value="0" />
                            </DataTrigger>
                            <DataTrigger Binding="{Binding ShowAdvanced}" Value="True">
                                <Setter Property="Width" Value="*" />
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ColumnDefinition.Style>
            </ColumnDefinition>
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
    </Grid>
