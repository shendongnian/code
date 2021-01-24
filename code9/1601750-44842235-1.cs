    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition></RowDefinition>
            <RowDefinition></RowDefinition>
        </Grid.RowDefinitions>
        <ListBox ItemsSource="{Binding Items}" Grid.Row="0">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid HorizontalAlignment="Stretch">
                        <Grid Height="29" Margin="5" HorizontalAlignment="Stretch">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="1*" />
                                <ColumnDefinition Width="1*" />
                            </Grid.ColumnDefinitions>
                            <TextBox Grid.Column="0" Text="{Binding Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                            <TextBox Grid.Column="1" Text="{Binding Value, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                        </Grid>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
        <Button Grid.Row="1" Content="Save" Command="{Binding SaveCommand}"></Button>
    </Grid>
