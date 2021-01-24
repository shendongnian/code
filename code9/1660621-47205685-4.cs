        <ListBox
            Margin="0,0,5,0"
            ItemsSource="{Binding Source={StaticResource ListBoxItems}}"
            SelectedIndex="-1"
            SelectedItem="{Binding SelectedBranch}">            
            <ListBox.GroupStyle>
                <GroupStyle>
                    <GroupStyle.Panel>
                        <ItemsPanelTemplate>
                            <VirtualizingStackPanel Orientation="Vertical" />
                        </ItemsPanelTemplate>
                    </GroupStyle.Panel>
                    <GroupStyle.ContainerStyle>
                        <Style TargetType="{x:Type GroupItem}">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate>
                                        <Expander
                                            Padding="0"                                           
                                            BorderThickness="0"
                                            Header="{Binding Name}"
                                            IsExpanded="True">
                                            <ItemsPresenter/>
                                        </Expander>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </GroupStyle.ContainerStyle>
                </GroupStyle>
            </ListBox.GroupStyle>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Border BorderThickness="0">
                        <Grid>                            
                            <StackPanel Orientation="Horizontal">                               
                                <TextBlock Text="{Binding FirshName}" />
                                <TextBlock Text="{Binding LastName}" />
                            </StackPanel>                            
                        </Grid>
                    </Border>
                </DataTemplate>
            </ListBox.ItemTemplate>
            <ListBox.ItemContainerStyle>
                <Style TargetType="{x:Type ListBoxItem}">
                    <Setter Property="Padding" Value="0" />
                    <Setter Property="Margin" Value="0" />
                </Style>
            </ListBox.ItemContainerStyle>
        </ListBox>
