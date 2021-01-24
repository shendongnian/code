     private static XslCompiledTransform LoadTransformations(HttpContext context, XslCompiledTransform cc)
        {
            
            using (var xmlReader = new XmlTextReader(context.Server.MapPath("/templates/xhtmlmain.xsl"))
            {
                DtdProcessing = DtdProcessing.Parse
            })
            {
                cc.Load(xmlReader);
            }
            return cc;
        }
        private static XslCompiledTransform CreateTransformation(HttpContext context)
        {
            var cc = new XslCompiledTransform();
            // Since our templates are most likely poorly written it takes
            // unusual amount of memory for a thread to handle the transformation
            // leaving the application throwing StackOverflow Exception.
            // This code creates different thread with 8MB stack size which actually succeeds in
            // transforming all the templates.
            // Creates custom thread and start it.  
            Thread t = new Thread(() => cc = GTHttpHandler.LoadTransformations(context, cc), 8 * 1024 * 1024);
            t.Start();
            // Ensure our transformation thread is finished before doing anything.
            t.Join();
            return cc;
        }
