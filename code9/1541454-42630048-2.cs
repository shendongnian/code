    // Define the group size
    const int GROUP_SIZE = 500;
    // Select a new object type that encapsulates the base item
    // and a new property called "Grouping" that will group the
    // objects based on their index relative to the group size
    var groups = in_dt
        .Rows
        .Select(
            (item, index) => new { Item = item, Grouping = Math.Floor(index / GROUP_SIZE) }
        )
        .GroupBy(item => item.Grouping)
    ;
    // Loop through the groups
    foreach (var group in groups) {
        // Generate a zip file for each group of files
    }
