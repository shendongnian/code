            var list = travelars.GroupBy(x => new { x.From, x.To }).ToList().Select(e => new { 
                MaleCount = e.Count(g => g.Gender == "M"),
                FemaleCount = e.Count(g => g.Gender == "F"),
                ChildCount = e.Count(g => g.Gender == "C"),
            });
