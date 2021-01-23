     foreach (Family per in tree.families) // <--- THE ERROR IS HERE
     {
                Console.WriteLine(per.FamilyName + " " + per.FamilyTotalReign);
                foreach (var ppl in per.People)
                {
                    Console.WriteLine(ppl.PersonName + " " + per.FamilyName);
                }
     }
