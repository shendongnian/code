    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // So my users can still login
            routes.MapRoute(
                name: "Account",
                url: "Account/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );
            // For the upload controller to work
            routes.MapRoute(
                name: "Upload",
                url: "Upload/{action}/{id}",
                defaults: new { controller = "Upload", action = "Index", id = UrlParameter.Optional }
            );
            // And finally registrating my custom handler
            routes.Add(new Route("{*path}", new CustomRouteHandler()));
            // This was the original routeconfig
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
    public class CustomRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new CustomHttpHandler();
        }
    }
    public class CustomHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void ProcessRequest(HttpContext context)
        {
            // Get the subdomain requested
            var subdomain = context.Request.Url.Authority.Split(new char[] { '.', ':' }).FirstOrDefault();
            // Get the directory info about the requested subdomain
            DirectoryInfo info = new DirectoryInfo(context.Server.MapPath("~/Websites/" + subdomain));
            // Check if subdomain is not empty and exists
            if (!string.IsNullOrEmpty(subdomain) && info.Exists)
            {
                // Get the requested filename
                var filename = context.Request.Url.PathAndQuery.Split(new char[] { '?' }).FirstOrDefault();
                // If the root is requested change to index.html
                if (filename == "/") filename = "/index.html";
                // Translate requested filename to server path
                var fullname = context.Server.MapPath("~/Websites/" + subdomain + filename);
                // Respond the file
                ResponseFile(context, fullname);
            }
            else
            {
                // Subdomain not found so end the request
                context.Response.End();
            }
        }
        public void ResponseFile(HttpContext context, string fullname)
        {
            // Clear the response buffer
            context.Response.Clear();
            System.IO.Stream oStream = null;
            try
            {
                // Open the file
                oStream =
                    new System.IO.FileStream
                        (path: fullname,
                        mode: System.IO.FileMode.Open,
                        share: System.IO.FileShare.Read,
                        access: System.IO.FileAccess.Read);
                // **************************************************
                context.Response.Buffer = false;
                // Setting the ContentType
                context.Response.ContentType = MimeMapping.GetMimeMapping(fullname);
                // Get the length of the file 
                long lngFileLength = oStream.Length;
                // Notify user (client) the total file length
                context.Response.AddHeader("Content-Length", lngFileLength.ToString());
                // **************************************************
                // Total bytes that should be read
                long lngDataToRead = lngFileLength;
                // Read the bytes of file
                while (lngDataToRead > 0)
                {
                    // Verify that the client is connected or not?
                    if (context.Response.IsClientConnected)
                    {
                        // 8KB
                        int intBufferSize = 8 * 1024;
                        // Create buffer for reading [intBufferSize] bytes from file
                        byte[] bytBuffers =
                            new System.Byte[intBufferSize];
                        // Read the data and put it in the buffer.
                        int intTheBytesThatReallyHasBeenReadFromTheStream =
                            oStream.Read(buffer: bytBuffers, offset: 0, count: intBufferSize);
                        // Write the data from buffer to the current output stream.
                        context.Response.OutputStream.Write
                            (buffer: bytBuffers, offset: 0,
                            count: intTheBytesThatReallyHasBeenReadFromTheStream);
                        // Flush (Send) the data to output
                        // (Don't buffer in server's RAM!)
                        context.Response.Flush();
                        lngDataToRead =
                            lngDataToRead - intTheBytesThatReallyHasBeenReadFromTheStream;
                    }
                    else
                    {
                        // Prevent infinite loop if user disconnected!
                        lngDataToRead = -1;
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                if (oStream != null)
                {
                    //Close the file.
                    oStream.Close();
                    oStream.Dispose();
                    oStream = null;
                }
                context.Response.Close();
                context.Response.End();
            }
        }
    }
