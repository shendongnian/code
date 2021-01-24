    private const string _select = "select * from country";
    
    void DoSomething()
    {
         string sql = string.Empty;
         if (combobox1.SelectedIndex > -1)
         {
             command.Parameters.AddWithValue("@1",  (string)combobox1.SelectedValue);
             sql = " where city_name = @1";
         }
         sql = _select + sql;
         command.CommandText = sql;
         command.Execute...
    }
