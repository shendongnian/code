    <GridViewColumn Width="130">
        <GridViewColumnHeader Content="Caracteristica" />
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <Grid>
                    <ComboBox x:Name="cmbCaracteristica" Width="100"
                             SelectedItem="{Binding SelectedItem}" />
                </Grid>
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
    <GridViewColumn Width="100">
        <GridViewColumnHeader Content="Tipo" />
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <Grid>
                    <TextBox x:Name="txtTipoValor"
                             Text="{Binding Path=SelectedItem, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" TextAlignment="Left"/>
                </Grid>
            </DataTemplate>
        </GridViewColumn.CellTemplate>
    </GridViewColumn>
