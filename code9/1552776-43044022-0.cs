    <Grid>
        <Grid.Resources>
            <CollectionViewSource x:Key="persons" Source="{Binding Persons}">
                <CollectionViewSource.GroupDescriptions>
                    <PropertyGroupDescription PropertyName="GroupName" />
                </CollectionViewSource.GroupDescriptions>
            </CollectionViewSource>
        </Grid.Resources>
        <DataGrid x:Name="gridMates" ItemsSource="{Binding Source={StaticResource persons}}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Name}" Header="Name" />
                <DataGridTextColumn Binding="{Binding DisplayName}" Header="DisplayName" />
            </DataGrid.Columns>
            <DataGrid.GroupStyle>
                <GroupStyle>
                    <GroupStyle.ContainerStyle>
                        <Style TargetType="{x:Type GroupItem}">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate TargetType="{x:Type GroupItem}">
                                        <Expander IsExpanded="True" >
                                            <Expander.Header>
                                                <DockPanel>
                                                    <TextBlock Text="{Binding Path=Name}" />
                                                </DockPanel>
                                            </Expander.Header>
                                            <Expander.Content>
                                                <ItemsPresenter />
                                            </Expander.Content>
                                        </Expander>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </GroupStyle.ContainerStyle>
                </GroupStyle>
            </DataGrid.GroupStyle>
        </DataGrid>
    </Grid>
