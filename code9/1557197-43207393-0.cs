    public static DataSet DBNull(DataSet dataSet)
        {
            try
            {
                foreach (DataTable dataTable in dataSet.Tables)
                    foreach (DataRow dataRow in dataTable.Rows)
                        foreach (DataColumn dataColumn in dataTable.Columns)
                            if (dataRow.IsNull(dataColumn))
                            {
                                if (dataColumn.DataType.IsValueType) dataRow[dataColumn] = Activator.CreateInstance(dataColumn.DataType);
                                else if (dataColumn.DataType == typeof(bool)) dataRow[dataColumn] = false;
                                else if (dataColumn.DataType == typeof(Guid)) dataRow[dataColumn] = Guid.Empty;
                                else if (dataColumn.DataType == typeof(string)) dataRow[dataColumn] = string.Empty;
                                else if (dataColumn.DataType == typeof(DateTime)) dataRow[dataColumn] = DateTime.MaxValue;
                                else if (dataColumn.DataType == typeof(int) || dataColumn.DataType == typeof(byte) || dataColumn.DataType == typeof(short) || dataColumn.DataType == typeof(long) || dataColumn.DataType == typeof(float) || dataColumn.DataType == typeof(double)) dataRow[dataColumn] = 0;
                                else dataRow[dataColumn] = null;
                            }
    
                return dataSet;
            }
            catch (Exception ex)
            {
                return dataSet;
            }
        }
