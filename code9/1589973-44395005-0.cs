    private void ExportGridToExcel()  {  
            Response.Clear();  
            //You had a typo on the line below in your code for (filename)
            Response.AddHeader("content-disposition", "attachment;filename=MainReport.xls");  
            Response.ContentType = "File/Data.xls";  
            StringWriter StringWriter = new System.IO.StringWriter();  
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);  
            GridEmpData.RenderControl(HtmlTextWriter);  
            Response.Write(StringWriter.ToString());  
            Response.End();  
        }  
