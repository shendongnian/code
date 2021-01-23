    var sb = new StringBuilder("DECLARE @T as Table (Id int, Name varchar(20), Type int ); ");
    sb.Append("INSERT INTO @T VALUES ");
    foreach (DataRow row in dt.Rows)
    {
        sb.Append("(").Append(row["Id"]).Append(", '");
        sb.Append(row["Name"]).Append("', '");
        sb.Append(row["Type"]).Append("'),");
    }
    sb.Remove(sb.Length - 1, 1);
    sb.Append(";UPDATE p ");
    sb.Append("SET p.Name = t.Name, ");
    sb.Append("p.Type = t.Type ");
    sb.Append("FROM Product AS p ");
    sb.Append("INNER JOIN @T AS t ON p.id = t.id");
            
    var query = sb.ToString();
