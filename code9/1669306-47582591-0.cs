    ClientContext ctx = new ClientContext("http://sp13");
     
    Folder folder = ctx.Web.GetFolderByServerRelativeUrl("Shared Documents");
    string file = String.Concat(Environment.CurrentDirectory, @"\Files\SharePointGuidance2010.pdf");
     
    List docLib = ctx.Web.Lists.GetByTitle("Documents");
    ctx.Load(docLib);
    ctx.ExecuteQuery();
     
    using (MemoryStream stream = new MemoryStream( System.IO.File.ReadAllBytes(file) ) )
    {
    Microsoft.SharePoint.Client.File.SaveBinaryDirect(ctx, "/shared documents/SubFolder/spg.pdf", stream, true);
    }
