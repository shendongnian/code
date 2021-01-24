    List<string> lstTicketType = new List<string>() { "Standard", "Standard", "Student", "Student", "Senior" };
            List<int> lstQuantity = new List<int>() { 1,1,1,1,1};
            List<double> lstAmount = new List<double>() {8.5 , 8.5 , 6.5 , 6.5 ,4};
            List<mergeClass> LstMC = new List<mergeClass>();
            for (int i = 0; i < lstTicketType.Count(); i++)
            {
                mergeClass NewMC = new mergeClass(lstTicketType[i], lstQuantity[i], lstAmount[i]);
                LstMC.Add(NewMC);
            }
            var query=LstMC.GroupBy(q=>q.TicketType)
                        .Select(q=>new{TicketType=q.First().TicketType,
                                        Quantity=q.Sum(a=>a.Quantity),
                                        Amount=q.Sum(a=>a.Amount)
                        }).ToList();
