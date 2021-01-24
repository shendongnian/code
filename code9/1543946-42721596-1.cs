    <DataGrid x:Name="dataGrid" AutoGenerateColumns="False">
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
