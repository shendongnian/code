        var db = new Data();
        var rng = new Random();
        if (!db.KillEvents.Any())
        {
            System.Console.WriteLine("Populating with test data");
            for (var i = 0; i < 100; i++)
            {
                var data = new KillEvent()
                {
                    killerPosX = rng.Next(0, 1000),
                    killerPosY = rng.Next(0, 1000),
                    killerSide = rng.Next(0, 3).ToString(),
                    victimPosX = rng.Next(0, 1000),
                    victimPosY = rng.Next(0, 1000),
                    victimSide = rng.Next(0, 3).ToString(),
                    weaponType = "AIM-" + (9 + Math.Round((int)rng.Next(0, 2) * 111.0)).ToString(),
                };
                db.KillEvents.Add(data);
                db.SaveChanges();
            }
        }
