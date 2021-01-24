    xmlns:controls="using:Microsoft.Toolkit.Uwp.UI.Controls"
     <Page.Resources>
        <CollectionViewSource x:Name="CVSposts" />
    </Page.Resources>
    <Grid>
        <controls:DataGrid x:Name="DataGridTTT" AutoGenerateColumns="False"  x:DefaultBindMode="TwoWay" Grid.Row="1" >
                <controls:DataGrid.Columns>
                    <controls:DataGridTextColumn Header="PostId"   Binding="{Binding PostId}" />
                    <controls:DataGridTextColumn Header="Title"  Binding="{Binding Title}" />
                <controls:DataGridTextColumn Header="Content1"  Binding="{Binding Content1}" />
                <controls:DataGridTemplateColumn Tag="Col">
                        <controls:DataGridTemplateColumn.CellTemplate>
                            <DataTemplate  >
                                <Grid Name="Grid1" Tag="{Binding BlogId, Mode=TwoWay , UpdateSourceTrigger=PropertyChanged}">
                                    <ComboBox  x:Name="ComboBoxTTT"     
                                SelectedValue="{Binding BlogId, Mode=TwoWay , UpdateSourceTrigger=PropertyChanged}"
                                    SelectedValuePath="BlogId"   DisplayMemberPath="Url"   ItemsSource="{Binding Blogss}"
                                    />
                                </Grid>
                            </DataTemplate>
                        </controls:DataGridTemplateColumn.CellTemplate>
                    </controls:DataGridTemplateColumn>
                </controls:DataGrid.Columns>
            </controls:DataGrid>
    </Grid>
