    <Expander.Header>
        <Border Background="#cccccc"  Margin="2 8 8 8" Height="52"
                            Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType=Window}}">
            <Border.ToolTip>
                <ToolTip>
                    <ToolTip.Resources>
                        <Style TargetType="TextBlock">
                            <Setter Property="Foreground" Value="#cccccc"/>
                        </Style>
                    </ToolTip.Resources>
                    <Border Background="#4d4d4d" BorderThickness="0.5"  CornerRadius="5" MinWidth="200">
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="200"/>
                                <ColumnDefinition Width="180"/>
                            </Grid.ColumnDefinitions>
                            <Border Grid.Column="0"   BorderBrush="Red" BorderThickness="0 0 0.5 0" MinHeight="200">
                                <ItemsControl ItemTemplate="{StaticResource PanelCardToolTip}"
                                              ItemsSource="{Binding PlacementTarget.Tag.ListVoci,RelativeSource={RelativeSource AncestorType=ToolTip}}" MinWidth="120">
                                    <ItemsControl.ItemsPanel>
                                        <ItemsPanelTemplate>
                                            <WrapPanel />
                                        </ItemsPanelTemplate>
                                    </ItemsControl.ItemsPanel>
                                </ItemsControl>
                            </Border>
                        </Grid>
                    </Border>
                </ToolTip>
            </Border.ToolTip>
            <TextBlock>....</TextBlock>
        </Border>
    </Expander.Header>
