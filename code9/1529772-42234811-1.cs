    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.SharePoint.Client;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected string SiteUrl = "http://mysite.mydomain.com/site";
        protected string LibraryName = "MyList";
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new ClientContext(SiteUrl);
            context.Load(context.Site);
            context.ExecuteQuery();
            var list = context.Web.Lists.GetByTitle(LibraryName);
            if (list == null)
            {
                throw new ArgumentException(string.Format("List with name '{0}' not found on site '{1}'", LibraryName, SiteUrl));
            }
            context.Load(list, l => l.RootFolder.ServerRelativeUrl);
            context.ExecuteQuery();
            // Empty query. You probably want to filter on something so
            // do a search on "CAML Query". Also watch out for SharePoint
            // List View Threshold which limits # of items that can be retrieved
            var camlQuery = @"<View Scope='All'><Query></Query></View>";
            var items = list.GetItems(camlQuery);
            context.Load(items, l => l.IncludeWithDefaultProperties(i => i.Folder, i => i.File, i => i.DisplayName)); 
            context.ExecuteQuery();
            
           // Url for first item
           var url = SiteUrl + "/" + LibraryName + "/" + items[0]["Title"]
        }
    }
