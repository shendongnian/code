    <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate >
                        <DataTemplate x:Name="dtAllChkBx">
                            <CheckBox Name="cbxAll">
                                <CheckBox.Style>
                                    <Style TargetType="CheckBox">
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding ElementName=wndMain, Path=LocationText , Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Value="" >
                                                <Setter Property="IsEnabled" Value="False" />
                                            </DataTrigger>
                                            <DataTrigger Binding="{Binding ElementName=wndMain, Path=LocationText, Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Value="01" >
                                                <Setter Property="IsEnabled" Value="True" />
                                            </DataTrigger>
                                            <DataTrigger Binding="{Binding ElementName=wndMain, Path=LocationText, Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Value="02" >
                                                <Setter Property="IsChecked" Value="True" />
                                                <Setter Property="IsEnabled" Value="False" />
                                            </DataTrigger>
                                            <DataTrigger Binding="{Binding ElementName=wndMain, Path=LocationText, Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" Value="03" >
                                                <Setter Property="IsChecked" Value="False" />
                                                <Setter Property="IsEnabled" Value="False" />
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </CheckBox.Style>
                            </CheckBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
