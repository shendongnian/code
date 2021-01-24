    <TreeView Grid.Row="4" DataContext="{StaticResource listings}"  ItemsSource="{Binding}" >
        <TreeView.GroupStyle>
            <GroupStyle>
                <GroupStyle.ContainerStyle>
                    <Style TargetType="{x:Type GroupItem}">
                        <Setter Property="Margin" Value="0,0,0,5"/>
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type GroupItem}">
                                    <Expander Margin="0,0,0,0" IsExpanded="True" BorderBrush="#FFA4B97F" BorderThickness="0,0,0,1">
                                        <Expander.Header>
                                            <DockPanel>
                                                <TextBlock FontWeight="Bold" Text="{Binding Path=Name}"/>
                                                <TextBlock Text=" : "/>
                                                <TextBlock FontWeight="Bold" Text="{Binding Path=ItemCount}"/>
                                                <TextBlock Text=" items(s)"/>
                                            </DockPanel>
                                        </Expander.Header>
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
                        <Setter Property="Margin" Value="0,0,0,5"/>
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type GroupItem}">
                                    <Expander Margin="0,0,0,0" IsExpanded="True" BorderBrush="#FFA4B97F"  BorderThickness="0,0,0,1">
                                        <Expander.Header>
                                            <DockPanel>
                                                <TextBlock FontWeight="Bold" Text="{Binding Path=Name}"/>
                                                <TextBlock Text=" : "/>
                                                <TextBlock FontWeight="Bold" Text="{Binding Path=ItemCount}"/>
                                                <TextBlock Text=" items(s)"/>
                                            </DockPanel>
                                        </Expander.Header>
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
