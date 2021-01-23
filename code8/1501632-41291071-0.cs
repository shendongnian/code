    <DataGrid CanUserAddRows="False" IsReadOnly="True" AutoGenerateColumns="False">
        <DataGrid.Style>
            <Style TargetType="DataGrid">
                <Setter Property="ItemsSource" Value="{Binding SomeCollection}" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SomeCollection.Count}" Value="0">
                        <Setter Property="ItemsSource">
                            <Setter.Value>
                                <CompositeCollection>
                                    <local:SomeRecord />
                                </CompositeCollection>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.Style>
        <DataGrid.Columns>
            <DataGridTextColumn Header="ID" Binding="{Binding ID}" Width="50"/>
            <DataGridTextColumn Header="Code" Binding="{Binding Code}" Width="130"/>
        </DataGrid.Columns>
    </DataGrid>
