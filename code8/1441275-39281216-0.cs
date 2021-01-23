    var avgResult = context.QuestionaireResults
                   .Where(r => (r.DepartureDate >= startDate && r.DepartureDate <= endDate))
                   .GroupBy( g => ((g.DepartureDate.Day % 7)+1), n => n.Number)
                   .Select( g => new
                    {
                       Week = g.Key,
                       Avg = g.Average()
                    }); 
