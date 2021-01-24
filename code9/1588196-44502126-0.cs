    public DataTable mergeSheetAndTextFile()
            {
                String name = "Sheet1";
                String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                "D:\\YOURPATH\\List.xlsx" +
                                ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
    
                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select col1,col2 From [" + name + "$]", con);
                con.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
    
                DataTable data = new DataTable();
                sda.Fill(data);
                 data.Columns.Add("Txt1Col", typeof(System.String));
                string[] txtFileLines= File.ReadAllLines("c://YOURPATH//test.txt");
               int count=0;
                 foreach (DataRow row in data.Rows)
                {
                     if(count<txtFileLines.Length){
                        row["Txt1Col"]=txtFileLines[count]
                        count++;`enter code here`
                     }
                }
    }
