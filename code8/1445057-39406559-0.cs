    <Window.Resources>
            <staticData:CountryList x:Key="CountryList"/>
        </Window.Resources>
    
        <Grid>
            <DataGrid ItemsSource="{Binding SampleList}"  AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="Countries" Width="100">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding SelectedCountry}"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
    
                        <DataGridTemplateColumn.CellEditingTemplate>
                            <DataTemplate>
                                <ComboBox Height="22" Grid.Row="0"
                                            ItemsSource="{StaticResource CountryList}"
                                            SelectedItem="{Binding SelectedCountry}">
                                </ComboBox>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellEditingTemplate>
    
                    </DataGridTemplateColumn>
    
                    <!-- Inputs -->
                    <DataGridTextColumn Width="SizeToCells" Header="Inputs" MinWidth="100" Binding="{Binding Input}" >
                        <DataGridTextColumn.CellStyle>
                            <Style TargetType="DataGridCell">
                                <Style.Triggers>
                                    <DataTrigger Binding="{Binding SelectedCountry}" Value="UK">
                                        <Setter Property="IsEnabled" Value="false"/>
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </DataGridTextColumn.CellStyle>
                    </DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
