    <DataGrid x:Name="dataGrid" AutoGenerateColumns="False" Margin="10,85,10,10" xmlns:local="clr-namespace:WpfApplication1">
        <DataGrid.Resources>
            <local:Converter x:Key="conv" />
        </DataGrid.Resources>
        <DataGrid.RowStyle>
            <Style TargetType="DataGridRow">
                <Setter Property="Background">
                    <Setter.Value>
                        <MultiBinding Converter="{StaticResource conv}">
                            <Binding Path="." />
                            <Binding Path="ItemsSource" RelativeSource="{RelativeSource AncestorType=DataGrid}" />
                        </MultiBinding>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.RowStyle>
        <DataGrid.Columns>
            <DataGridTextColumn Header="AmountNeed" Binding="{Binding AmountNeed}" />
            <DataGridTextColumn Header="TotalLose" Binding="{Binding TotalLose}" />
            <DataGridTextColumn Header="TotalGain" Binding="{Binding TotalGain}" />
            <DataGridTextColumn Header="TotalCost" Binding="{Binding TotalCost}" />
            <DataGridTemplateColumn Header="Image">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Image Source="{Binding ImageSource}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
----------
    for (int z = 0; z<list_Exp.Count; z++)
    {
        var d = new MyDataObject();
        d.AmountNeed = Math.Ceiling((goalexp - currentexp) / (list_Exp[z]));
        d.TotalLose = d.AmountNeed* (list_Amount_MadeFrom_One[z] * list_BuyPrice_MadeFrom_One[z] + list_Amount_MadeFrom_Two[z] * list_BuyPrice_MadeFrom_Two[z]);
        d.TotalGain = d.AmountNeed* list_AmountMade[z] * list_SellPrice[z];
        d.TotalCost = d.TotalGain - d.TotalLose;
        d.ImageSource = new Uri(@"c:\test\pic.png", UriKind.RelativeOrAbsolute);
        L.Add(d);
    }
