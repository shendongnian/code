     private void GenerateTableDefinitionPart1Content(TableDefinitionPart tableDefinitionPart1)
        {
            Table table1 = new Table(){ Id = (UInt32Value)1U, Name = "Table1", DisplayName = "Table1", Reference = "A1:D2", TotalsRowShown = false };
            AutoFilter autoFilter1 = new AutoFilter(){ Reference = "A1:D2" };
            TableColumns tableColumns1 = new TableColumns(){ Count = (UInt32Value)4U };
            TableColumn tableColumn1 = new TableColumn(){ Id = (UInt32Value)1U, Name = "1" };
            TableColumn tableColumn2 = new TableColumn(){ Id = (UInt32Value)2U, Name = "2" };
            TableColumn tableColumn3 = new TableColumn(){ Id = (UInt32Value)3U, Name = "3" };
            TableColumn tableColumn4 = new TableColumn(){ Id = (UInt32Value)4U, Name = "4" };
            tableColumns1.Append(tableColumn1);
            tableColumns1.Append(tableColumn2);
            tableColumns1.Append(tableColumn3);
            tableColumns1.Append(tableColumn4);
            TableStyleInfo tableStyleInfo1 = new TableStyleInfo(){ Name = "TableStyleLight17", ShowFirstColumn = false, ShowLastColumn = false, ShowRowStripes = true, ShowColumnStripes = false };
            table1.Append(autoFilter1);
            table1.Append(tableColumns1);
            table1.Append(tableStyleInfo1);
            tableDefinitionPart1.Table = table1;
        }
