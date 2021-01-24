       string[] ratings = new string[] {
         "F-", "A+", "B", "B-", "B+", "A-", "F", "E"
       };
       
       // Inplace sorting
       Array.Sort(ratings, (left, right) => string.Compare(
         left.PadRight(2, ','), 
         right.PadRight(2, ','), 
         StringComparison.OrdinalIgnoreCase));
       // Alternative Linq version
       var sortedRatings = ratings
         .OrderBy(rating => rating.PadRight(2, ','))
         .ToArray();
    
       Console.Write(string.Join(", ", ratings));
