      [WebMethod]
         public static string ExportExcel()
         {
            Export objExort = new Export();
            return    objExort.Excel();
           
         }
    
         public class Export
            {
                public string Excel()
                {
                     GridView1.AllowPaging = false;
                    GridView1.DataBind();
                    return null;
                }
            }
