    <Grid>
        <ListBox ItemsSource="{Binding Colls,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock ToolTip="{Binding Name, Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" TextTrimming="WordEllipsis" Text="{Binding Path=Name, Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"/>
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
        <Button Click="Button_Click" Width="100" Height="50" Content="Click Me" />
    </Grid>
