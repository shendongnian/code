    public class MyEntityTableSqlGenerator : EntityTableSqlGenerator
    {
        protected override void UpdateTableColumn(ColumnModel columnModel, TableColumnType tableColumnType)
        {
            //for system column deleted
            switch (tableColumnType)
            {
                case TableColumnType.Deleted:
                    columnModel.DefaultValue = 0;
                    break;
            }
            base.UpdateTableColumn(columnModel, tableColumnType);
        }
        protected override void Generate(CreateTableOperation createTableOperation)
        {
            //for your custom columns
            foreach (ColumnModel column in createTableOperation.Columns)
            {
                TableColumnType tableColumnType = this.GetTableColumnType(column);
                if (tableColumnType == TableColumnType.None)
                {
                    if (column.Annotations.Keys.Contains("DefaultValue"))
                    {
                        var value = Convert.ChangeType(column.Annotations["DefaultValue"].NewValue, column.ClrDefaultValue.GetType());
                        column.DefaultValue = value;
                    }
                }
            }
            //for system columns
            base.Generate(createTableOperation);
        }
    }
