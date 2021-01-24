    <Grid>
        <Grid.Resources>
            <CollectionViewSource x:Key="groups" Source="{Binding Groups}">
                <CollectionViewSource.GroupDescriptions>
                    <PropertyGroupDescription PropertyName="GroupName" />
                </CollectionViewSource.GroupDescriptions>
            </CollectionViewSource>
        </Grid.Resources>
        <DataGrid x:Name="gridMates" ItemsSource="{Binding Source={StaticResource groups}}" AutoGenerateColumns="False">
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
                                                <ItemsControl ItemsSource="{Binding Path=Items[0].CLGroup}">
                                                    <ItemsControl.ItemTemplate>
                                                        <DataTemplate>
                                                            <StackPanel>
                                                                <TextBlock Text="{Binding Path=DisplayName}"/>
                                                            </StackPanel>
                                                        </DataTemplate>
                                                    </ItemsControl.ItemTemplate>
                                                </ItemsControl>
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
