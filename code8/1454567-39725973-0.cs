            <DataGrid ItemsSource="{Binding}" >
            <DataGrid.GroupStyle>
                <!-- Style for groups at top level. -->
                <GroupStyle>
                    <GroupStyle.ContainerStyle>
                        <Style TargetType="{x:Type GroupItem}">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate TargetType="{x:Type GroupItem}">
                                        <Expander IsExpanded="True">
                                            <Expander.Header>
                                                <DockPanel>
                                                    <TextBlock FontWeight="Bold"
                                                               Text="{Binding Path=Name}" />
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
