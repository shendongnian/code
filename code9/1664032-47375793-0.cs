     public sealed class KillerContextInitialization : DropCreateDatabaseAlways<KillerContext>
        {
            protected override void Seed(KillerContext db)
            {
                List<Killer> killers = new List<Killer>();
                
        
                killers.Add(new Killer(name: "Ivan Firstein", biography: "He was born in the shadows."));
                killers.Add(new Killer(name: "Oleg Gazmanov", biography: "test man"));
    
                db.SaveChanges(); // - save killers first, then add them to contract
                db.Contracts.Add(new Contract(
                        Contract.Status.active,
                        killers.SingleOrDefault(x => x.Name == "Ivan Firstein"),
                        "KILL OR BE KILLED. As always with love.",
                        killers.SingleOrDefault(x => x.Name == "Oleg Gazmanov")
                        ));
        
                db.Killers.AddRange(killers);
                base.Seed(db);
            }
        }
