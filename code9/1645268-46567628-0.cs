    public class BindedDataGrid : DataGridView
        {
            public BindedDataGrid()
            {
            }
    
            public BindedDataGrid(Type bindType)
            {
                IEnumerable<PropertyInfo> properties = bindType.GetProperties().Where(p => Attribute.IsDefined(p, typeof(BindingValueAttribute)));
    
                foreach (PropertyInfo property in properties)
                {
                    var prop = property.GetCustomAttributes(true)[0];
                    if (prop is BindingValueAttribute)
                    {
                        var column = new DataGridViewColumn()
                        {
                            HeaderText = property.Name
                        };
                        column.CellTemplate = new DataGridViewTextBoxCell();
                        Columns.Add(column);
                    }
                }
            }
        }
    
        public class BindingValueAttribute  : Attribute
        {
            public string Value { get; set; }
        }
    
        public class BindOne
        {
            [BindingValueAttribute()]
            public string Name { get; set; }
    
            [BindingValueAttribute()]
            public int Age { get; set; }
        }
 
