    <DataGrid HeadersVisibility="Column" Name="griglia" Grid.Row="2" ItemsSource="{Binding Path=Test}" AutoGenerateColumns="True" IsReadOnly="True" ScrollViewer.CanContentScroll="True" ScrollViewer.VerticalScrollBarVisibility="Visible" ScrollViewer.HorizontalScrollBarVisibility="Visible">
        <DataGrid.ColumnHeaderStyle>
            <Style TargetType="{x:Type DataGridColumnHeader}">
                <Setter Property="ContentTemplate" >
                    <Setter.Value>
                        <DataTemplate DataType="DataGridColumnHeader">
                            <ComboBox ToolTip="{Binding RelativeSource={RelativeSource Self}, Path=SelectedValue}" ItemContainerStyle="{StaticResource SingleSelectionComboBoxItem}" DisplayMemberPath="Oggetto" Width="100" Height="20" ItemsSource="{Binding RelativeSource={RelativeSource AncestorType={x:Type DataGrid}},Path=DataContext.Selezione, UpdateSourceTrigger=LostFocus}"  SelectionChanged="SingleSelectionComboBox_SelectionChanged"/>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.ColumnHeaderStyle>
    </DataGrid>
