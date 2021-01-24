    public class HomeController : Controller
    {
        public ActionResult UploadFilePost(string SubmitButton, HttpPostedFileBase file)
        {
            if (SubmitButton == "Upload RTF")
            {
                //I use BreazEntities13, you will use what comes out of the EDMX wizard
                //EDMX is easy please try it
                byte[] byteContent;
                Stream aStream = file.InputStream;
                MemoryStream memoryStream = new MemoryStream();
                aStream.CopyTo(memoryStream);
                byteContent = memoryStream.ToArray();
                ImportMod imsk = new ImportMod
                {
                    Contents = byteContent,
                    ContentType = "text/plain"
                };
                using (BreazEntities13 entity = new BreazEntities13())
                {
                    entity.ImportMods.Add(imsk);
                    entity.SaveChanges();
                }
            }
            else if (SubmitButton == "Download RTF")
            {
                //get documnet
                ImportMod kit = new ImportMod();
                using (BreazEntities13 entity = new BreazEntities13())
                {
                    kit = entity.ImportMods.FirstOrDefault();  //! GETS only the first documument
                }
                //modify file -credit to other stack o pages
                //eg http://stackoverflow.com/questions/9174402/replacing-the-innertext-of-an-xml-node-element
                XmlDocument doc = new XmlDocument();
                string xml = Encoding.UTF8.GetString(kit.Contents);
                doc.LoadXml(xml);
                doc.SelectSingleNode("div").InnerText = "Replace text, xmldocument is similiar to rtf or choose a diff type";
                byte[] bytes = Encoding.Default.GetBytes(doc.OuterXml);
                this.ControllerContext.HttpContext.Response.ClearContent();
                this.ControllerContext.HttpContext.Response.ContentType = "text/plain";
                this.ControllerContext.HttpContext.Response.AddHeader("content-disposition",
                "attachment; filename=" + "AAnRTF.txt");
                this.ControllerContext.HttpContext.Response.BinaryWrite(bytes);
                this.ControllerContext.HttpContext.Response.End();
            }
            return View("UploadFile");
        }
        public ActionResult UploadFile()
        {
            return View();
        }
