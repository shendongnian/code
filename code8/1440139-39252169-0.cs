    private enum structureType
    { None, Circle, Square, Pyramid}
    ...
    dtStruct = new DataTable();
    dtStruct.Columns.Add("Name", typeof(string));
    dtStruct.Columns.Add("Type", typeof(string));
    dtStruct.Columns.Add("Structure", typeof(structureType));
    dtStruct.Columns.Add("Count", typeof(int));
    
    // autogen columns == true
    dgv2.DataSource = dtStruct;
    
    // create DataSource as list of Name-Value pairs from enum
    var cboSrc = Enum.GetNames(typeof(structureType)).
                        Select( x => new {Name = x, 
                                          Value = (int)Enum.Parse(typeof(structureType),x)
                                          }
                               ).ToList();
    
    // replace auto Text col with CBO col
    DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn();
    cb.ValueType = typeof(structureType);
    cb.DataSource = cboSrc;
    cb.DisplayMember = "Name";          // important
    cb.ValueMember = "Value";           // important
    cb.HeaderText = "Structure";
    cb.DataPropertyName = "Structure";  // where to store the value
    dgv2.Columns.Remove(dgv2.Columns[2]);  // remove txt col
    dgv2.Columns.Add(cb);
    cb.DisplayIndex = 2;
    
    // add data
    dtStruct.Rows.Add("Ziggy", "Foo", structureType.Circle, 6);
