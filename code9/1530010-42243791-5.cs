    private void ExportGridToExcel()  
    {  
       Response.Clear();  
       Response.Buffer = true;  
       Response.ClearContent();  
       Response.ClearHeaders();  
       Response.Charset = "";  
       string FileName ="SampleFileName"+DateTime.Now+".xls";  
       StringWriter strwritter = new StringWriter();  
       HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);        
       Response.Cache.SetCacheability(HttpCacheability.NoCache);  
       Response.ContentType ="application/vnd.ms-excel";    
       Response.AddHeader("Content-Disposition","attachment;filename=" + FileName);  
       GridView1.GridLines = GridLines.Both;  
       GridView1.HeaderStyle.Font.Bold = true;  
       GridView1.RenderControl(htmltextwrtter);  
       Response.Write(strwritter.ToString());  
       Response.End();      
    }  
