    <DataGrid Grid.Row="3" Grid.Column="1" AutoGenerateColumns="False" FontSize="18" ItemsSource="{Binding Path=MyProperty, NotifyOnSourceUpdated=True, UpdateSourceTrigger=PropertyChanged}">
                <DataGrid.Columns>
                    <DataGridCheckBoxColumn Binding="{Binding Path=Status, UpdateSourceTrigger=PropertyChanged}" Header="Verify" Width="1*"/>
                    <DataGridTextColumn Binding="{Binding Path=Id, UpdateSourceTrigger=PropertyChanged}" Header="PalletID" IsReadOnly="True" Width="2*"/>
                    <DataGridTemplateColumn>
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <Button IsEnabled="{Binding Status}">I am a button</Button>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
