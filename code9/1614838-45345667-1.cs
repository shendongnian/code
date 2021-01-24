    var failCodes = new List<FailCode>
    {
        new FailCode { Code = 1, Description = "Fail one" };
        new FailCode { Code = 2, Description = "Fail two" };
        new FailCode { Code = 3, Description = "Fail three" };
    }
    comboboxColumn.ValueMember = "Code"; //will use "Code" as identifier
    comboboxColumn.DisplayMember = "Description"; //will use "Description" as item text   
    comboboxColumn.DataSource = failCodes;
    comboboxColumn.DataPropertyName = "FailCodeByOP"; //will select item with same "Code" value
   
