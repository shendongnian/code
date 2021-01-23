            DataFrame dataFrame = null;
            IEnumerable[] columns = new IEnumerable[dt.Columns.Count];
            string[] columnNames = dt.Columns.Cast<DataColumn>()
                                   .Select(x => x.ColumnName)
                                   .ToArray();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                switch (Type.GetTypeCode(dt.Columns[i].DataType))
                {
                    case TypeCode.String:
                        columns[i] = dt.Rows.Cast<DataRow>().Select(row => row.Field<string>(i)).ToArray();
                        break;
                    case TypeCode.Double:
                        columns[i] = dt.Rows.Cast<DataRow>().Select(row => row.Field<double>(i)).ToArray();
                        break;
                    case TypeCode.Int32:
                        columns[i] = dt.Rows.Cast<DataRow>().Select(row => row.Field<int>(i)).ToArray();
                        break;
                    case TypeCode.Int64:
                    case TypeCode.Decimal:
                        IEnumerable array = dt.Rows.Cast<DataRow>().Select(row => row.Field<object>(i)).ToArray();
                                                
                        //columns[i] = dt.Rows.Cast<DataRow>().Select(row => row.Field<long>(i)).ToArray();
                        //columns[i] = dt.Rows.Cast<DataRow>().Select(row => row.Field<decimal>(i)).ToArray();
                        columns[i] = ListToIenumerable(array);
                        break;
                    default:
                        columns[i] = dt.Rows.Cast<DataRow>().Select(row => row[i]).ToArray();
                        //throw new InvalidOperationException(String.Format("Type {0} is not supported", dt.Columns[i].DataType.Name));
                        break;
                }
            }
            dataFrame = REngine.CreateDataFrame(columns: columns, columnNames: columnNames, stringsAsFactors: false);
            REngine.SetSymbol(name, dataFrame);
            return dataFrame;
        }
