    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="100" />
            <ColumnDefinition Width="100" />
        </Grid.ColumnDefinitions>
        <ToggleButton>
            <ToggleButton.Style>
                <Style>
                    <!-- <Setter Property="Grid.Column" Value="0" /> optional, see below for explanation -->
                    <Style.Triggers>
                        <Trigger Property="ToggleButton.IsChecked" Value="True">
                            <Setter Property="Grid.Column" Value="1" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </ToggleButton.Style>
        </ToggleButton>
    </Grid>
