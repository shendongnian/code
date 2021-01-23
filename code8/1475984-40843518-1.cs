    public void UseComboBoxForEnumsAndBools(DataGridView g)
    {
        g.Columns.Cast<DataGridViewColumn>()
         .Where(x => x.ValueType == typeof(bool) || x.ValueType.IsEnum)
         .ToList().ForEach(x =>
         {
             var index = x.Index;
             this.dataGridView1.Columns.RemoveAt(index);
             var c = new DataGridViewComboBoxColumn();
             c.ValueType = x.ValueType;
             if (x.ValueType == typeof(bool))
             {
                 c.DataSource = new List<bool>() { true, false }.Select(b => new
                 {
                     Value = b,
                     Name = b ? "Yes" : "No" /*or simply b.ToString*/
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
             c.ValueMember = "Value";
             c.DisplayMember = "Name";
             c.DataPropertyName = x.DataPropertyName;
             c.HeaderText = x.HeaderText;
             g.Columns.Insert(index, c);
         });
    }
