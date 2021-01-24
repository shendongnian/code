    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication2
    {
        class Program
        {
            class Stats
            {
                public int level;
                public int exp;
            }
            class InputObj
            {
                public string orig_rsn;
                public string rsn;
                public Dictionary<string, Stats> stats;
            }
            const string sampleString = "{\"orig_rsn\":\"hotcrumbs\",\"rsn\":\"hotcrumbs\",\"stats\":{\"overall\":{\"level\":167,\"exp\":38759},\"attack\":{\"level\":20,\"exp\":4493},\"defence\":{\"level\":20,\"exp\":4497},\"strength\":{\"level\":10,\"exp\":1185},\"constitution\":{\"level\":26,\"exp\":8884},\"range\":{\"level\":30,\"exp\":13448},\"prayer\":{\"level\":10,\"exp\":1188},\"magic\":{\"level\":2,\"exp\":102},\"cooking\":{\"level\":9,\"exp\":1030},\"woodcutting\":{\"level\":15,\"exp\":2590},\"fletching\":{\"level\":1,\"exp\":0},\"fishing\":{\"level\":5,\"exp\":500},\"firemaking\":{\"level\":4,\"exp\":360},\"crafting\":{\"level\":1,\"exp\":0},\"smithing\":{\"level\":1,\"exp\":80},\"mining\":{\"level\":5,\"exp\":402},\"herblore\":{\"level\":1,\"exp\":0},\"agility\":{\"level\":1,\"exp\":0},\"thieving\":{\"level\":1,\"exp\":0},\"slayer\":{\"level\":1,\"exp\":0},\"farming\":{\"level\":1,\"exp\":0},\"runecrafting\":{\"level\":1,\"exp\":0},\"hunter\":{\"level\":1,\"exp\":0},\"construction\":{\"level\":1,\"exp\":0},\"summoning\":{\"level\":1,\"exp\":0},\"dungeoneering\":{\"level\":1,\"exp\":0},\"divination\":{\"level\":1,\"exp\":0},\"duel\":{\"level\":1},\"bh\":{\"level\":1},\"bhr\":{\"level\":1},\"fog\":{\"level\":1}}}";
            static void Main(string[] args)
            {
                var customer1 = JsonConvert.DeserializeObject<InputObj>(sampleString);
                //System.Console.WriteLine(customer1.orig_rsn);
                foreach( var x in customer1.stats)
                {
                    System.Console.WriteLine("Key: "+x.Key);
                    System.Console.WriteLine("Level: " + x.Value.level);
                    System.Console.WriteLine("Exp: " + x.Value.exp);
                }
                System.Console.ReadKey();
            }
        }
    }
