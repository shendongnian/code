    public class DataTableTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return typeof(DataTable).IsAssignableFrom(type);
        }
        public object ReadYaml(IParser parser, Type type)
        {
            var table = new DataTable();
            parser.Expect<MappingStart>();
            ReadColumns(parser, table);
            ReadRows(parser, table);
            parser.Expect<MappingEnd>();
            return table;
        }
        private static void ReadColumns(IParser parser, DataTable table)
        {
            var columns = parser.Expect<Scalar>();
            if (columns.Value != "columns")
            {
                throw new YamlException(columns.Start, columns.End,
                                        "Expected a scalar named 'columns'");
            }
            parser.Expect<MappingStart>();
            while (parser.Allow<MappingEnd>() == null)
            {
                var columnName = parser.Expect<Scalar>();
                var typeName = parser.Expect<Scalar>();
                table.Columns.Add(columnName.Value, Type.GetType(typeName.Value));
            }
        }
        private static void ReadRows(IParser parser, DataTable table)
        {
            var columns = parser.Expect<Scalar>();
            if (columns.Value != "rows")
            {
                throw new YamlException(columns.Start, columns.End,
                                        "Expected a scalar named 'rows'");
            }
            parser.Expect<SequenceStart>();
            while (parser.Allow<SequenceEnd>() == null)
            {
                var row = table.NewRow();
                var columnIndex = 0;
                parser.Expect<SequenceStart>();
                while (parser.Allow<SequenceEnd>() == null)
                {
                    var value = parser.Expect<Scalar>();
                    var columnType = table.Columns[columnIndex].DataType;
                    row[columnIndex] = TypeConverter.ChangeType(value.Value, columnType);
                    ++columnIndex;
                }
                table.Rows.Add(row);
            }
        }
        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            var table = (DataTable)value;
            emitter.Emit(new MappingStart());
            EmitColumns(emitter, table);
            EmitRows(emitter, table);
            emitter.Emit(new MappingEnd());
        }
        private static void EmitColumns(IEmitter emitter, DataTable table)
        {
            emitter.Emit(new Scalar("columns"));
            emitter.Emit(new MappingStart(null, null, true, MappingStyle.Block));
            foreach (DataColumn column in table.Columns)
            {
                emitter.Emit(new Scalar(column.ColumnName));
                emitter.Emit(new Scalar(column.DataType.AssemblyQualifiedName));
            }
            emitter.Emit(new MappingEnd());
        }
        private static void EmitRows(IEmitter emitter, DataTable table)
        {
            emitter.Emit(new Scalar("rows"));
            emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Block));
            foreach (DataRow row in table.Rows)
            {
                emitter.Emit(new SequenceStart(null, null, true, SequenceStyle.Flow));
                foreach (var item in row.ItemArray)
                {
                    var value = TypeConverter.ChangeType<string>(item);
                    emitter.Emit(new Scalar(value));
                }
                emitter.Emit(new SequenceEnd());
            }
            emitter.Emit(new SequenceEnd());
        }
    }
