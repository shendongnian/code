    using System;
    using Microsoft.Exchange.WebServices.Data;
    using System.Net;
    using System.IO;
    using System.Diagnostics;
    
    namespace EWS_API
    {
        class Program
        {
            static void Main(string[] args)
            {
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange010_SP);
    
                service.Credentials = new NetworkCredential("user", "pwd", "domain");
    
                service.TraceEnabled = true;
                service.TraceFlags = TraceFlags.All;
    
    			// ignore certificate errors
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
    
    			// set ews uri without autodiscover (just for internal use)
                service.Url = new Uri("https://fqdn_server/EWS/exchange.asmx");
    			
    			// filter for only daily mails
                SearchFilter searchFilter = new SearchFilter.IsGreaterThan(ItemSchema.DateTimeReceived, DateTime.Now.AddDays(-1));
    
                ItemView itemView = new ItemView(int.MaxValue);
                FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, searchFilter, itemView);
    
                if (findResults != null && findResults.Items != null && findResults.Items.Count > 0)
                    foreach (Item item in findResults.Items)
                    {
                        EmailMessage message = EmailMessage.Bind(service, item.Id, new PropertySet(BasePropertySet.IdOnly, ItemSchema.Attachments, ItemSchema.HasAttachments));
                        foreach (Attachment attachment in message.Attachments)
                        {
                            if (attachment is FileAttachment)
                            {
                                FileAttachment fileAttachment = attachment as FileAttachment;
                                fileAttachment.Load();
                                fileAttachment.Load("C:\\temp\\" + fileAttachment.Name);
                            }
                        }
                        Debug.WriteLine(item.Subject);
                    }
                else
                    Debug.WriteLine("no items");
            }
        }
    }
