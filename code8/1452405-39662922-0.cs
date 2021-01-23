    <tb:TaskbarIcon PopupActivation="LeftOrRightClick">
        <tb:TaskbarIcon.TrayPopup>
            <Grid Background="White">
                <Grid.RowDefinitions>
                    <RowDefinition Height="200"/>
                    <RowDefinition Height="30"/>
                </Grid.RowDefinitions>
                <ScrollViewer Grid.Row="0">
                    <ItemsControl ItemsSource="{Binding NumberList, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <Grid>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="200"/>
                                        <ColumnDefinition/>
                                    </Grid.ColumnDefinitions>
                                    <Label Grid.Column="0" Content="{Binding Id, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}"/>
                                    <Button Grid.Column="1" Content="Test" Command="{Binding ElementName=trayMainStack, Path=DataContext.TestCommand}"/> <!--Updated binding works!-->
                                </Grid>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <StackPanel Name="trayMainStack"/>
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                    </ItemsControl>
                </ScrollViewer>
                <Button Grid.Row="1" Content="Test2" Command="{Binding TestCommand}"/> <!--This works-->
            </Grid>
        </tb:TaskbarIcon.TrayPopup>
    </tb:TaskbarIcon>
