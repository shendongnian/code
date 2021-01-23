    string output = @"output.csv";
    ...
    // Hash set is effcient - O(N) - for testing if line exists or not  
    HashSet<String> existingLines = new HashSet<String>(File
      .ReadLines(output));
    //TODO: please, check this selection (I'm not sure in ReplayBuild and Map attributes) 
    var toAppend = replay
      .Players
      .Select(player => new {
         toWrite = string.Join(",", player.ReplayBuild, player.Map),
         isWinner = player.IsWinner })
      .Where(item => existingLines.Contains(item.toWrite))
      .OrderByDescending(item => item.isWinner)
      .Select(item => item.toWrite)
      .ToList(); // since we're writing into the same file, we have to materialize
    // Do we have anything to write?
    if (toAppend.Any())
      File.AppendAllLines(output, toAppend);  
