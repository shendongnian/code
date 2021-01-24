    using(MySqlCommand cmd = new MySqlCommand())
    {
       cmd.Connection = connection;
       cmd.CommandText = sql;
       dataReader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
       schemaTable = dataReader.GetSchemaTable();
       int i = 1;
       while(dataReader.Read())
       {
          foreach(DataRow field in schemaTable.Rows)
          {
             if(field.Field<String>("ColumnName") != "id")
             {
                TextBox textBox = new TextBox();
                textBox.Name = field.Field<String>("ColumnName");
                textBox.Tag = field.Field<Boolean>("AllowDBNull");
                textBox.Text = dataReader[i].ToString();
                
                 StackPanel.Children.Add(textBox);
                 i++;
             }
          }
       }
