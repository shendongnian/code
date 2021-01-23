     <ComboBox.ItemTemplate>
     <DataTemplate>
     <ContentControl>
        <Style TargetType="ContentControl">
            <Style.Triggers>
                <DataTrigger Binding="{Binding ...}" Value="True">
                    <Setter Property="Content">
                        <Setter.Value>
                                <Grid>
                                    <Grid.Style>
                                        <Style TargetType="Grid">
                                            <Setter Property="Background" Value="#FFE6E6FA"/>
                                        </Style>
                                    </Grid.Style>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="Auto" />
                                        <ColumnDefinition Width="Auto" />
                                    </Grid.ColumnDefinitions>
                                    <Label Content="{Binding}" Width="250" />
                                    <Button Grid.Column="1" Command="{Binding CommandButton, ElementName=root}"
                            CommandParameter="{Binding}">+</Button>
                                </Grid>
                            </Setter.Value>
                    </Setter>
                </DataTrigger>
                <DataTrigger Binding="{Binding ...}" Value="False">
                    <Setter Property="Content">
                        <Setter.Value>
                                <Grid>
                                    <Grid.Style>
                                        <Style TargetType="Grid">
                                            <Setter Property="Background" Value="Yellow"/>
                                        </Style>
                                    </Grid.Style>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="Auto" />
                                        <ColumnDefinition Width="Auto" />
                                    </Grid.ColumnDefinitions>
                                    <Label Content="{Binding}" Width="250" />
                                    <Button Grid.Column="1" Command="{Binding CommandButton, ElementName=root}"
                                        CommandParameter="{Binding}">-</Button>
                                </Grid>
                            </Setter.Value>
                    </Setter>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </ContentControl>
    </DataTemplate>
    </ComboBox.ItemTemplate>
