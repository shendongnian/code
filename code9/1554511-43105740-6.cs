    [System.Web.Services.WebMethod]
    public static List<string> Search()
    {
        List<string> results;
        //ListBox1.Items.Clear();
        results = OleDb.fDbReadToArray(@"SELECT Project_Name from tProjectNames where Project_Name like '" + Local_String_to_be_passed from asp.NET + "%'");
        //foreach (string item in results)
        //{
        //    ListBox1.Items.Add(item);
        //}
        return results;
    }
