    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string xml =
                @"<?xml version=""1.0""?>
                <Customers>
                    <Customer>
                        <details>
                            <id/>
                        </details>
                        <details>
                            <id/>
                        </details>
                    </Customer>
                </Customers>";
            XElement xel = XElement.Parse(xml);
            XDocument x = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), new XElement(xel));
            context.Response.ContentType = "application/xml";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=Test.xml");
            context.Response.AddHeader("Content-Length", xml.Length.ToString());
            x.Save(context.Response.OutputStream);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
