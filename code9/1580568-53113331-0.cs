        public static class DataTableSerializer
    {
        public static byte[] FastSerialize(this DataTable tbl, out string tableSchema)
        {
            var tableItems = new object[tbl.Rows.Count][];
            for (var rowIndex = 0; rowIndex < tbl.Rows.Count; rowIndex++)
                tableItems[rowIndex] = tbl.Rows[rowIndex].ItemArray;
            var serializationFormatter = new BinaryFormatter();
            using (var buffer = new MemoryStream())
            {
                serializationFormatter.Serialize(buffer, tableItems);
            
                var tableSchemaBuilder = new StringBuilder();
                tbl.WriteXmlSchema(new StringWriter(tableSchemaBuilder));
                tableSchema = tableSchemaBuilder.ToString();
            
                return buffer.ToArray();
            }
        }
        public static DataTable FastDeserialize(byte[] serializedData, string tableSchema)
        {
            var table = new DataTable();
            table.ReadXmlSchema(new StringReader(tableSchema));
            var serializationFormatter = new BinaryFormatter();
            object[][] itemArrayForRows;
            using (var buffer = new MemoryStream(serializedData))
            {
                itemArrayForRows = (object[][]) serializationFormatter.Deserialize(buffer);
            }
            table.MinimumCapacity = itemArrayForRows.Length;
            table.BeginLoadData();
            for (var index = 0; index < itemArrayForRows.Length; index++)
            {
                var t = itemArrayForRows[index];
                table.Rows.Add(t);
            }
            table.EndLoadData();
            return table;
        }
    }
