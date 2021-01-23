    var objectBuilder = new StringBuilder();
    objectBuilder.AppendLine("public class QueryResult");
    objectBuilder.AppendLine("{");
    foreach (DataColumn column in dataTable.Columns)
    {
        objectBuilder.AppendLine(String.Format("public {0} {1} { get; set; }", column.DataType.Name, column.ColumnName));
    }
    objectBuilder.AppendLine("}");
