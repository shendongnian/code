    private DataTable GetDescriptionForEnumColumn(DataTable dt, dynamic columnsInfo)
        {
            foreach (var item in columnsInfo)
            {
                string strIDColumnName = item.IDColumnName;
                string strNewColumnName = item.IDColumnName + "Description";
                Enum columnEnumName = item.ColumnType;
    
                dt.Columns.Add(strNewColumnName);
                foreach (DataRow row in dt.Rows)
                {
                    if ((ConvertTo.Integer(row[strIDColumnName]) > 0))
                        row[strNewColumnName] = SystemEnum.GetEnumDescriptionFromString(Enum.Parse(columnEnumName.GetType(), ConvertTo.String(row[strIDColumnName]), true).ToString(), columnEnumName.GetType());
                }
            }
    
            return dt;
        }
