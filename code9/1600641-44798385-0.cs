    <DataGrid   ItemsSource="{Binding  Path=CardGroupSecond}">
    
            <DataGrid.ColumnHeaderStyle>
                <Style BasedOn="{StaticResource {x:Type DataGridColumnHeader}}" TargetType="{x:Type DataGridColumnHeader}">
                    <Setter Property="LayoutTransform">
                        <Setter.Value>
                            <TransformGroup>
                                <RotateTransform Angle="90"/>
                            </TransformGroup>
                        </Setter.Value>
                    </Setter>
                </Style>
            </DataGrid.ColumnHeaderStyle>
            <DataGrid.LayoutTransform>
                <TransformGroup>
                    <RotateTransform Angle="-90"/>
                </TransformGroup>
            </DataGrid.LayoutTransform>
            <DataGrid.Columns>
    
                <DataGridTemplateColumn  Header="Type">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBox Background="Red" Width="40" VerticalAlignment="Stretch" HorizontalAlignment="Stretch"  Text="{Binding Path=SlotTypeValue}"                                                                         
                                                                             >
                                <TextBox.LayoutTransform>
                                    <TransformGroup>
                                        <RotateTransform Angle="90"/>
                                    </TransformGroup>
                                </TextBox.LayoutTransform>
                            </TextBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn  Header="Slot">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button   VerticalAlignment="Stretch" HorizontalAlignment="Stretch"  Content="{Binding Path=Slot}"                                                                         
                                                                             >
                                <Button.LayoutTransform>
                                    <TransformGroup>
                                        <RotateTransform Angle="90"/>
                                    </TransformGroup>
                                </Button.LayoutTransform>
                            </Button>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
