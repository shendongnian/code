    using Microsoft.Web.Administration;
     ServerManager web = new ServerManager();
                    web.Sites["Default Web Site"].Applications.Add("/Web", Drive + "/Portal/Web");
                    web.Sites["Default Web Site"].Applications.Add("/WebAPI", Drive + "/Portal/WebAPI");
                    web.CommitChanges();
