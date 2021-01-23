                    Application appOne = new Application
                {
                    Id = 7,
                    ApplicationName = "AppOne",
                    ApplicationPosotion = new Position { Id = 5, PositionName = "123" }
                };
                db.Positions.AddOrUpdate(appOne.ApplicationPosotion);
                db.Applications.AddOrUpdate(appOne);
                db.SaveChanges();
                appOne = db.Applications.Find(7);
                Console.WriteLine(appOne.ApplicationPosotion.PositionName);
