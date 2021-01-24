        using System;
        using Microsoft.TeamFoundation.Client;
        using Microsoft.TeamFoundation.WorkItemTracking.Client;
        using Microsoft.TeamFoundation.WorkItemTracking.Proxy;
        using System.IO;
        
        namespace GetAdmin
        {
            class Program
            {
                static void Main(string[] args)
                {
        
                    TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri("https://xxx.visualstudio.com/"));
                    ttpc.EnsureAuthenticated();
                    WorkItemStore wistore = ttpc.GetService<WorkItemStore>();
                    WorkItem wi = wistore.GetWorkItem(111);
                    WorkItemServer wiserver = ttpc.GetService<WorkItemServer>();
                    string tmppath = wiserver.DownloadFile(wi.Attachments[0].Id);
                    string filename = @"D:\test\test.docx";
                    File.Copy(tmppath,filename);
                }
            }
    
    }
