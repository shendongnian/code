    try
    {
        Response.Clear();    
        Response.ContentType = "application/vnd.ms-excel.template.macroEnabled.12";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", @"Excel_Template_" + DateTime.Now.ToString("yyyy-dd-M-HH-mm") + ".xltm"));
    
        Response.BinaryWrite(System.IO.File.ReadAllBytes(HostingEnvironment.MapPath("~/Template/manipulated_Excel_Template.xltm")));
        Response.End();
    }
    catch (Exception Ex)
    {
        ...
    }
