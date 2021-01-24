    public static void ExportXML_v1_2(SqlString file_path, SqlString file_name,
       SqlXml xml_data, out int status, out SqlString error_messages)
    {
        if (file_path.IsNull)
        {
           error_messages = "@file_path cannot be NULL.";
           return;
        }
        string Folder1 = file_path.Value;
 
