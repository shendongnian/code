     var ordered = cards.SelectMany(c => c.CardRoles.Select(r => new { Card = c, Role = r }))
          .OrderBy(a => a.Role.DependentRoles.Count)
          .ThenBy(a => a.Card.ComputerName)
          .ThenBy(a => a.Role.RoleName)
          .Select(c => c.Card);
