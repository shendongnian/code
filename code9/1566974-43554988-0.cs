    var result =
       ctx
       .Headers
       .ToDictionary(          
          header => new {
             header.Id,
             header.Items.First().ItemSequence
          },
          header =>
             header
             .Items
             .Select(item => item.Value)
             .ToList()
       );
