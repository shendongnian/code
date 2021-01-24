    <DataGrid x:Name="ModelControl" AutoGenerateColumns="False" ItemsSource="{Binding List3}">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding MyName}" Header="Modellname" />
            <DataGridTemplateColumn Header="Header 1">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ComboBox x:Name="ComboBox1" DisplayMemberPath="MyName" 
                                          SelectedIndex="{Binding YourIndexProperty}">
                            <ComboBox.ItemsSource>
                                <CompositeCollection>
                                    <CollectionContainer Collection="{Binding Source={StaticResource Source2}}" />
                                </CompositeCollection>
                            </ComboBox.ItemsSource>
                        </ComboBox>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <DataGridTemplateColumn Header="Header 2">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ComboBox x:Name="ComboBox2" DisplayMemberPath="MyName">
                            <ComboBox.Style>
                                <Style TargetType="{x:Type ComboBox}">
                                    <Setter Property="IsEnabled" Value="True" />
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding YourIndexProperty}" Value="0">
                                            <Setter Property="IsEnabled" Value="False" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </ComboBox.Style>
                            <ComboBox.ItemsSource>
                                <CompositeCollection>
                                    <CollectionContainer Collection="{Binding Source={StaticResource Source1}}" />
                                </CompositeCollection>
                            </ComboBox.ItemsSource>
                        </ComboBox>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
