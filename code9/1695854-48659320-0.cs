    using System;
    using Microsoft.SharePoint.Client;
    namespace Microsoft.SDK.SharePointFoundation.Samples
    {
      class List_getItemByIdExample
      {
        static void Main()
        {
            string siteUrl = "http://MyServer/sites/MySiteCollection";
            ClientContext clientContext = new ClientContext(siteUrl);
            Web site = clientContext.Web;
            List targetList = site.Lists.GetByTitle("Announcements");
            // Get the list item from the Announcements list whose Id is 4. 
            // Note that this is the ID of the item in the list, not a reference to its position.
            ListItem targetListItem = targetList.GetItemById(4);
            // Load only the title.
            clientContext.Load(targetListItem,
                             item => item["Title"]);
            clientContext.ExecuteQuery();
            Console.WriteLine("Request succeeded. \n\n");
            Console.WriteLine("Retrieved item is: {0}", targetListItem["Title"]);
        }
      }
    }
