    public string GetPDF(string pHTML)
        {
            byte[] pdf;
            using (var memoryStream = new MemoryStream())
            {
                using (var doc = new Document(PageSize.A4, 15, 15, 15, 15))
                {
                    var writer = PdfWriter.GetInstance(doc, memoryStream);
                    writer.PageEvent = new PDFEvents();
                    doc.Open();
                    var html = pHTML;
                    var tagProcessors = (DefaultTagProcessorFactory)Tags.GetHtmlTagProcessorFactory();
                    tagProcessors.RemoveProcessor(HTML.Tag.IMG); // remove the default processor
                    tagProcessors.AddProcessor(HTML.Tag.IMG, new CustomImageTagProcessor()); // use our new processor
                    CssFilesImpl cssFiles = new CssFilesImpl();
                    cssFiles.Add(XMLWorkerHelper.GetInstance().GetDefaultCSS());
                    var cssResolver = new StyleAttrCSSResolver(cssFiles);
                    var cssText = System.IO.File.ReadAllText(HttpContext.Server.MapPath("~/Content/bootstrap.css"));
                    cssText = cssText + System.IO.File.ReadAllText(HttpContext.Server.MapPath("~/Content/styles.css"));
                    cssResolver.AddCss(cssText, "utf-8", true);
                    var charset = Encoding.UTF8;
                    var hpc = new HtmlPipelineContext(new CssAppliersImpl(new XMLWorkerFontProvider()));
                    hpc.SetAcceptUnknown(true).AutoBookmark(true).SetTagFactory(tagProcessors); // inject the tagProcessors
                    var htmlPipeline = new HtmlPipeline(hpc, new PdfWriterPipeline(doc, writer));
                    var pipeline = new CssResolverPipeline(cssResolver, htmlPipeline);
                    var worker = new XMLWorker(pipeline, true);
                    var xmlParser = new XMLParser(true, worker, charset);
                    xmlParser.Parse(new StringReader(html));
                }
                pdf = memoryStream.ToArray();
            }
         
            var str= Convert.ToBase64String(pdf);
            return str;}
