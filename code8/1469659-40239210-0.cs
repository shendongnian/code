     var query = db.View_VisitorsForm.Where(o => o.VisitingDate >= new DateTime(2016,10,01) && o.VisitingDate <= new DateTime(2016, 10, 30)).GroupBy(G => G.Employee)
    
    foreach (var item in query)
                    {
                        Console.WriteLine($"Employee Id {item.Key} : Count :{item.Count()}");
                    }
                               
