    using System;
    using System.Collections.Generic;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Framework.Client;
    using Microsoft.TeamFoundation.Framework.Common;
    using Microsoft.VisualStudio.Services.Client;
    using Microsoft.VisualStudio.Services.Common;
    
    namespace ConsoleApplication3
    
    {
    
        class Program
    
        {
            static void Main(string[] args)
    
            {
    
                TfsConfigurationServer tcs = new TfsConfigurationServer(new Uri("http://xxxx:8080/tfs/"));
    
                IIdentityManagementService ims = tcs.GetService<IIdentityManagementService>();
    
                TeamFoundationIdentity tfi = ims.ReadIdentity(IdentitySearchFactor.AccountName, "domain\\username", MembershipQuery.Direct, ReadIdentityOptions.None);
                Console.WriteLine("Listing Groups for:" + tfi.DisplayName);
                Console.WriteLine("Total " + tfi.MemberOf.Length + " groups.");
                IdentityDescriptor[] group = tfi.MemberOf;
                foreach (IdentityDescriptor id in group)
                {
                    TeamFoundationIdentity detail = ims.ReadIdentity(IdentitySearchFactor.Identifier, id.Identifier, MembershipQuery.None, ReadIdentityOptions.None);
                    Console.WriteLine(detail.DisplayName);
                }
                Console.ReadLine();
    
            }
        }
    }
