    using System;
    using System.IO;
    using System.Net;
    using Independentsoft.Exchange;
    namespace Sample
    {
        class Program
        {
            static void Main(string[] args)
            {
                NetworkCredential credential = new NetworkCredential("username", "password");
                Service service = new Service("https://myserver3/ews/Exchange.asmx", credential);
                try
                {
                   ItemShape itemShape = new ItemShape(ShapeType.Id);
                   FindItemResponse inboxItems = service.FindItem(StandardFolder.Inbox, itemShape);
                   for (int i = 0; i < inboxItems.Items.Count; i++)
                   {
                       Independentsoft.Msg.Message msgFile = service.GetMessageFile(inboxItems.Items[i].ItemId);
                       msgFile.Save("c:\\test\\message" + i + ".msg", true);
                   }
                }
                catch (ServiceRequestException ex)
                {
                   Console.WriteLine("Error: " + ex.Message);
                   Console.WriteLine("Error: " + ex.XmlMessage);
                   Console.Read();
                }
                catch (WebException ex)
                {
                   Console.WriteLine("Error: " + ex.Message);
                   Console.Read();
                }
            }
        }
     }
