                    Application appOne = new Application
                {
                    Id = 7,
                    ApplicationName = "AppOne",
                    ApplicationPosition = new Position
                    {
                        Id = 5,
                        PositionName = "123",
                        SalaryAmount = new Salary() { Id = 1, SalaryAmount = 200000 }
                    }
                };
                db.Salarys.AddOrUpdate(appOne.ApplicationPosition.SalaryAmount);
                db.Positions.AddOrUpdate(appOne.ApplicationPosition);
                db.Applications.AddOrUpdate(appOne);
                db.SaveChanges();
                appOne = db.Applications.Find(7);
                Console.WriteLine(appOne.ApplicationPosition.SalaryAmount.SalaryAmount);
