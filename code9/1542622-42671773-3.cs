    string file = File.ReadAllText(@"E:\Projects\testApp\testApp\bin\Debug\file.txt");
    string textAfterFrom = file.After(" from ");
    string textBeforeFrom = file.Before(" from ");
    string[] textArrayAfterSelect = textBeforeFrom.After("select").Split(',');
    List<ColumnTableRelation> ListofTable = new List<ColumnTableRelation>();
    ColumnTableRelation objRel = new ColumnTableRelation();
    string[] splitTables = textAfterFrom.Split('\n');
    foreach (string tableNames in splitTables)
    {
       objRel = new ColumnTableRelation();
       if (!string.IsNullOrEmpty(tableNames) & !tableNames.Equals("\r"))
       {
           if (tableNames.Contains("dbo."))
           {
              if (tableNames.Contains("inner join"))
              {
                objRel.Tablename = tableNames.Between("inner join", " on ").Trim();
              }
              else
              {
                objRel.Tablename = tableNames.Before("\r").Trim();
              }
           }
           ListofTable.Add(objRel);
       }
    }
    foreach (var item in ListofTable)
    {
       string[] stringArray = textArrayAfterSelect;
       string value = item.Tablename.After(" ");
       var matchingvalues = stringArray.Where(stringToCheck => stringToCheck.Contains(value));
       List<string> listString = new List<string>();
       foreach (var match in matchingvalues)
       {
          listString.Add(match);
       }
       item.ColumnNames = listString;
    }
    StringBuilder builder = new StringBuilder();
    foreach (var item in ListofTable)
    {
       builder.Append(Environment.NewLine);
       builder.Append("Table name => " + item.Tablename + Environment.NewLine);
       foreach (var columns in item.ColumnNames)
       {
          builder.Append("Column name => " + columns + Environment.NewLine);
       }
    }
    string yourResult = builder.ToString();
    MessageBox.Show(yourResult);
    
