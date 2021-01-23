    var avgResult = context.QuestionaireResults
                   .Where(r => (r.DepartureDate >= startDate && r.DepartureDate <= endDate)).ToList()
                   .GroupBy( g => (Decimal.Round(g.DepartureDate.Day / 7)+1))
                   .Select( g => new
                    {
                       Week = g.Key,
                       Avg = g.Average(n => n.Number)
                    }); 
