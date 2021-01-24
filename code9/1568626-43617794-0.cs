    List<SelectListItem> matchingClientUserAndCandidateViews = allClientUserAndCandidateViews
          .GroupBy(x => new {x.Value, x.Text})
          .Where(g => g.Count() > 1)
          .Select(y => y.First())
          .ToList();
     List<SelectListItem> matchClientUserAndCandidateViews = allClientUserAndCandidateViews
          .GroupBy(x => new {x.Value, x.Text})               
          .Where(g => g.Skip(1).Any())   
          .SelectMany(g => g)           
          .ToList();
