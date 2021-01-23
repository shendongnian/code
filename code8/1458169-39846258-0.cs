    var regex = new Regex("(A)(bC*)*");
    var match = regex.Matches("AbCCbbCbCCCCbbb")
         .Cast<Match>()
         .SelectMany(x => x.Groups.Cast<Group>()
              .SelectMany(v => v.Captures
                  .Cast<Capture>()
                  .Select(t => t.Value)
              )
         )
         .ToList();
     foreach (var s in match)
         Console.WriteLine(s);
