    using System.Linq;
    
    var ListFinal = List1.Join(
            List2,
            (inner) => inner[0],
            (outer) => outer[0],
            (inner,outer) => new[]{ inner[0],inner[1],outer[1] })
        .ToList();
