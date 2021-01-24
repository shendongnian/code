    <TreeView ItemsSource="{Binding Items}">
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Path=Children, Mode=OneWay}">
                <CheckBox Content="{Binding Text, Mode=OneWay}" IsChecked="{Binding IsSelected}">
                    <CheckBox.Style>
                        <Style TargetType="CheckBox">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding IsSelected}" Value="True">
                                    <DataTrigger.Setters>
                                        <Setter Property="Foreground" Value="Red" />
                                    </DataTrigger.Setters>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </CheckBox.Style>
                </CheckBox>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
