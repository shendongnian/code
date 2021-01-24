    <TreeView Grid.Row="4" DataContext="{StaticResource listings}"  ItemsSource="{Binding}" >
        <TreeView.Resources>
            <Style TargetType="GroupItem">
                <Setter Property="Margin" Value="0,0,0,5"/>
            </Style>
            <Style TargetType="Expander">
                <Setter Property="Margin" Value="0,0,0,0" />
                <Setter Property="IsExpanded" Value="True" />
                <Setter Property="BorderBrush" Value="#FFA4B97F" />
                <Setter Property="BorderThickness" Value="0,0,0,1" />
                <Setter Property="Header" Value="{Binding}" />
                <Setter Property="HeaderTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <DockPanel>
                                <TextBlock FontWeight="Bold" Text="{Binding Path=Name}"/>
                                <TextBlock Text=" : "/>
                                <TextBlock FontWeight="Bold" Text="{Binding Path=ItemCount}"/>
                                <TextBlock Text=" items(s)"/>
                            </DockPanel>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </TreeView.Resources>
        <TreeView.GroupStyle>
            <GroupStyle>
                <GroupStyle.ContainerStyle>
                    <Style TargetType="{x:Type GroupItem}">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type GroupItem}">
                                    <Expander>
                                        <Expander.Content>
                                            <ItemsPresenter Margin="20,0,0,0" />
                                        </Expander.Content>
                                    </Expander>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </GroupStyle.ContainerStyle>
            </GroupStyle>
            <GroupStyle>
                <GroupStyle.ContainerStyle>
                    <Style TargetType="{x:Type GroupItem}">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type GroupItem}">
                                    <Expander>
                                        <Expander.Content>
                                            <ListView ItemsSource="{Binding Items}">
                                                <ListView.View>
                                                    <GridView>
                                                        <GridViewColumn Header="First Name" DisplayMemberBinding="{Binding FirstName}"/>
                                                        <GridViewColumn Header="Last Name" DisplayMemberBinding="{Binding LastName}"/>
                                                    </GridView>
                                                </ListView.View>
                                            </ListView>
                                        </Expander.Content>
                                    </Expander>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </GroupStyle.ContainerStyle>
            </GroupStyle>
        </TreeView.GroupStyle>
    </TreeView>
