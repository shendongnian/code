    static class OperationsWithCollections
    {
        internal static DataTable ConvertDoubleArrayToDataTable(double[] inputDoubleArray)
        {
            // New table.
            DataTable table = new DataTable();
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            table.Columns.Add(column);
            List<double[]> listOfDoubleArrays = new List<double[]>();
            foreach (double item in inputDoubleArray)
            {
                double[] oneElementDoubleArray = new double[1];
                oneElementDoubleArray[0] = item;
                listOfDoubleArrays.Add(oneElementDoubleArray);
            }
            // Add rows.
            foreach (var doubleArray in listOfDoubleArrays)
            {
                DataRow row = table.NewRow();
                row.ItemArray = doubleArray.Select(d => (object)d).ToArray(); //cast double array (double[]) to object array (object [])
                table.Rows.Add(row);
            }
            return table;
        }
    }
