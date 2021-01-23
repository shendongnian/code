    var resultDS = HtmlTablesToDataset(html);
    foreach(DataTable dt in resultDS.Tables)
    {
        Console.WriteLine("Table: " + dt.TableName);
        string line = "";
        foreach (DataColumn col in dt.Columns)
        {
            line += col.ToString() + " ";
        }
        Console.WriteLine(line.Trim());
        foreach (DataRow row in dt.Rows)
        {
            line = "";
            foreach (DataColumn col in dt.Columns)
            {
                line += row[col].ToString() + " ";
            }
            Console.WriteLine(line.Trim());
        }
    }
