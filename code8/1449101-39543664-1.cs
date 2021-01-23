    <ListBox Name="KeyListBox" ItemsSource="{Binding MobileCollection}" HorizontalAlignment="Left" Height="Auto" VerticalAlignment="Top" Width="300" HorizontalContentAlignment="Stretch">
        <ListBox.InputBindings>
            <KeyBinding Key="Enter" Command="{Binding DataContext.SelectItemCommand, ElementName=lstBox}" CommandParameter="{Binding SelectedItem, RelativeSource={RelativeSource FindAncestor, AncestorType=ListBox}}"/>
        </ListBox.InputBindings>
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Button Command="{Binding DataContext.SelectItemCommand, ElementName=lstBox}" CommandParameter="{Binding }" Foreground="Black" Padding="12 10" HorizontalContentAlignment="Left">
                        <Button.Content>
                            <StackPanel>
                                <CheckBox IsChecked="{Binding IsSelected, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Foreground="#404040">
                                    <CheckBox.Content>
                                        <StackPanel Orientation="Horizontal">
                                            <TextBlock Text="{Binding Name, IsAsync=True}" TextWrapping="Wrap" MaxWidth="270" />
                                        </StackPanel>
                                    </CheckBox.Content>
                                </CheckBox>
                            </StackPanel>
                        </Button.Content>
                    </Button>
                </Grid>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
