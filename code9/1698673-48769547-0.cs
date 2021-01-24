    <ControlTemplate TargetType="{x:Type ContentControl}" x:Name="cont">
    <Grid Width="{TemplateBinding Width}" Height="{TemplateBinding Height}">
        <Grid.RowDefinitions>
            <RowDefinition Height="auto" />
            <RowDefinition Height="auto" />
        </Grid.RowDefinitions>
        <Border Canvas.ZIndex="1" CornerRadius="4" BorderThickness="1" BorderBrush="Black" Background="{StaticResource btn3d}">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="32" />
                    <ColumnDefinition Width="1" />
                    <ColumnDefinition Width="2*" />
                </Grid.ColumnDefinitions>
                <ToggleButton Name="toggleButton" Padding="30, 10">
                    <ToggleButton.Template>
                        <ControlTemplate TargetType="ToggleButton">
                            <ControlTemplate.Triggers>
                                <EventTrigger RoutedEvent="ToggleButton.Checked">
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetProperty="Tag" From="0" To="60" Duration="0:0:0.5" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </EventTrigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </ToggleButton.Template>
                </ToggleButton>
                <StackPanel Grid.Column="2" />
            </Grid>
        </Border>
        <ListBox Name="lstBx" Height="{Binding ElementName="toggleButton" Grid.Row="1" ItemsSource="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=ItemsSource}" />
    </Grid>
    </ControlTemplate>
