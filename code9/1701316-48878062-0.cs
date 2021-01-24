    var result = db.FeatureAssigned
          // If you have a filter add the .Where() here ...
          .GroupBy(e => e.Featureid)
          .ToList()
          // Because the ToList(), this select projection is not done in the DB
          .Select(eg => new 
           {
              Feature= eg.Key,
              AssignedTo = string.Join(",", eg.Select(b=>b.AssignedTo )),
              Stories = string.Join(",", eg.Select(c=>c.storyid)),
              CompletedHrs= eg.Sum(z=>z.CompletedHrs)
           });
