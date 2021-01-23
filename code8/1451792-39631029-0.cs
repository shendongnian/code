    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        var column1Value = Row.Column1;
        var column2Value = Row.Column2;
        var column3Value = Row.Column3;
        var column4Value = Row.Column4;
        var column5Value = Row.Column5;
        
        while(column5Value.Length > 0)
        {
            var rowData = "";
            if (column5Value.Length > 4)
            {
                rowData = column5Value.Substring(0, 4);
                column5Value = column5Value.Substring(4);
            }
            else
            {
                rowData = column5Value;
                column5Value = "";
            }
            Output0Buffer.AddRow();
            Output0Buffer.Column1 = column1Value;
            Output0Buffer.Column2 = column2Value;
            Output0Buffer.Column3 = column3Value;
            Output0Buffer.Column4 = column4Value;
            Output0Buffer.Column5 = rowData;            
        }
    }
