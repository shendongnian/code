    using System;
    using System.Collections.Generic;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Build.WebApi;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Uri tfsurl = new Uri("http://xxxx:8080/tfs/CollectionName");
                TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(tfsurl);
                BuildHttpClient bhc = ttpc.GetClient<BuildHttpClient>();
                List<Build> builds = bhc.GetBuildsAsync("ProjectName").Result;
                foreach (Build bu in builds)
                {
                    Console.WriteLine(bu.BuildNumber);
                }
                Console.ReadLine();
            }
        }
    }
 
