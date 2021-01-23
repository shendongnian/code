    public void UseComboBoxForEnumsAndBools(DataGridView g)
    {
        g.Columns.Cast<DataGridViewColumn>()
         .Where(x => x.ValueType == typeof(bool) || x.ValueType.IsEnum)
         .ToList().ForEach(x =>
         {
             var index = x.Index;
             g.Columns.RemoveAt(index);
             var c = new DataGridViewComboBoxColumn();
             c.ValueType = x.ValueType;
             c.ValueMember = "Value";
             c.DisplayMember = "Name";
             c.DataPropertyName = x.DataPropertyName;
             c.HeaderText = x.HeaderText;
             c.Name = x.Name;
             if (x.ValueType == typeof(bool))
             {
                 c.DataSource = new List<bool>() { true, false }.Select(b => new
                 {
                     Value = b,
                     Name = b ? "True" : "False" /*or simply b.ToString() or any logic*/
                 }).ToList();
             }
             else if (x.ValueType.IsEnum)
             {
                 c.DataSource = Enum.GetValues(x.ValueType).Cast<object>().Select(v => new
                 {
                     Value = (int)v,
                     Name = Enum.GetName(x.ValueType, v) /* or any other logic to get text */
                 }).ToList();
             }
             g.Columns.Insert(index, c);
         });
    }
