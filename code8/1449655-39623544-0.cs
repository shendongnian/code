         <DataGrid Name="SelectionSetsGrid" CanUserAddRows="False" CanUserResizeColumns="True" CanUserSortColumns="True" 
                          ItemsSource="{Binding SelectionSets}" AutoGenerateColumns="False"
                          SelectedItem="{Binding SelectedSelectionSet}">
                    <DataGridComboBoxColumn Header="{StaticResource XpStrTopologyWidth}" SelectedItemBinding="{Binding LineWidthIndex, UpdateSourceTrigger=PropertyChanged}">
                        <DataGridComboBoxColumn.ElementStyle>
                            <Style TargetType="ComboBox" BasedOn="{StaticResource Theme.ComboBox.Style}">
                                <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}, Path=DataContext.LineWidths}"/>
                                <Setter Property="IsReadOnly" Value="True"/>
                                <Setter Property="ItemTemplate">
                                    <Setter.Value>
                                        <DataTemplate>
                                            <WrapPanel>
                                                <TextBlock Text="{Binding Converter={StaticResource IntToIntTextOrDefaultConverter}}" VerticalAlignment="Center"/>
                                            </WrapPanel>
                                        </DataTemplate>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </DataGridComboBoxColumn.ElementStyle>
                        <DataGridComboBoxColumn.EditingElementStyle>
                            <Style TargetType="ComboBox" BasedOn="{StaticResource Theme.ComboBox.Style}">
                                <Setter Property="ItemsSource" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type UserControl}}, Path=DataContext.LineWidths}"/>
                                <Setter Property="ItemTemplate">
                                    <Setter.Value>
                                        <DataTemplate>
                                            <WrapPanel>
                                                <TextBlock Text="{Binding Converter={StaticResource IntToIntTextOrDefaultConverter}}" VerticalAlignment="Center"/>
                                            </WrapPanel>
                                        </DataTemplate>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </DataGridComboBoxColumn.EditingElementStyle>
                    </DataGridComboBoxColumn>                        
                </DataGrid.Columns>
            </DataGrid>
