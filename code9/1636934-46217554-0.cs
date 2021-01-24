    String str; // this has the results of query in csv
    string file_name; // name of the file,
    Response.Clear();
    Response.ContentType = "text/csv";
    Response.AddHeader("Content-disposition", "attachment; filename=\"" + file_name + "\"");
    Response.Write(str);
    Response.Flush();
    Response.End();
