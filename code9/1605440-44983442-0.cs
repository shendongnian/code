    using System;
    using System.Linq;
    using Microsoft.Web.Administration;
    class Program
    {
        static void Main(string[] args)
        {
            var server = new ServerManager();
            var site = server.Sites.FirstOrDefault(s => s.Name == "Default Web Site");
            if (site != null)
            {
                //stop the site
                site.Stop();
                //start the site
                site.Start();
            }
           
        }
    }
