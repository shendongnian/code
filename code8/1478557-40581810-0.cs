    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Build.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string tfsurl = "http://tfscollectionurl";
                TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(tfsurl));
                VersionControlServer vcs = ttpc.GetService<VersionControlServer>();
                string[] path = { "$/Path/To/Item.cs" };
                ItemSpec[] itemSpecs = ItemSpec.FromStrings(path, RecursionType.Full);
                ItemSpec itemSpec = itemSpecs.Cast<ItemSpec>().First();
                IEnumerable<Changeset> changesets = vcs.QueryHistory(itemSpec);
                Changeset latestchangeset = changesets.Cast<Changeset>().First();
                Console.WriteLine(latestchangeset.Committer);
                Console.WriteLine(latestchangeset.CommitterDisplayName);
                Console.WriteLine(latestchangeset.Owner);
                Console.WriteLine(latestchangeset.OwnerDisplayName);
                Console.WriteLine(latestchangeset.CreationDate);
                Console.ReadLine();
            }
        }
    }
