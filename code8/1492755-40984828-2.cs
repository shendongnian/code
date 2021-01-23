    <ListBox.ItemTemplate>
        <DataTemplate>
            <DataTemplate.Resources>
                <Style x:Key="style" TargetType="ToggleButton">
                    <Setter Property="Opacity" Value="0" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsMouseOver, RelativeSource={RelativeSource AncestorType=ListBoxItem}}"
                                     Value="True">
                            <DataTrigger.EnterActions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimation Storyboard.TargetProperty="Opacity"
                                            From="0" To="1" Duration="0:0:1" />
                                    </Storyboard>
                                </BeginStoryboard>
                            </DataTrigger.EnterActions>
                            <DataTrigger.ExitActions>
                                <BeginStoryboard>
                                    <Storyboard>
                                        <DoubleAnimation Storyboard.TargetProperty="Opacity"
                                            From="1" To="0" Duration="0:0:1" />
                                    </Storyboard>
                                </BeginStoryboard>
                            </DataTrigger.ExitActions>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </DataTemplate.Resources>
            <Grid HorizontalAlignment="Stretch">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="1*" />
                    <ColumnDefinition x:Name="AnimeatedGrid" Width="Auto" />
                </Grid.ColumnDefinitions>
                <StackPanel Orientation="Horizontal">
                    <ToggleButton  />
                    <ToggleButton />
                    <TextBlock VerticalAlignment="Center" Text="{Binding Name}" />
                </StackPanel>
                <StackPanel Grid.Column="1" Orientation="Horizontal">
                    <ToggleButton Content="A" Style="{StaticResource style}" />
                    <ToggleButton Content="B" Style="{StaticResource style}" />
                </StackPanel>
            </Grid>
        </DataTemplate>
    </ListBox.ItemTemplate>
