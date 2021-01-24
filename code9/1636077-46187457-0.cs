      XDocument document = XDocument.Load(@"PATH TO XML");
           
            var mHistory = from r in document.Descendants("MaintenanceHistory")
                        select new
                        {
                            RepairDate = r.Element("RepairDate").Value,
                            Mileage = r.Element("Mileage").Value,
                            ActivityDescs = r.Descendants("Activity").Select(x => x.Element("Description").Value)
                        };
            foreach (var r in mHistory)
            {
                foreach (var activityDesc in r.ActivityDescs)
                {
                    Console.WriteLine(string.Format("{0} {1} {2} {3}", r.RepairDate, r.Mileage, activity,  Environment.NewLine));
                }
                
            }  
