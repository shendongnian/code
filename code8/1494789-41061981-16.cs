     string[] cubes = new string[]
       {"1|6", "2|8", "3|0", "4|0", "5|0", "6|0", "7|1", "8|4"};
      var result = cubes
        .Select (cube => new {
          name = cube.Substring(0, cube.IndexOf('|')),
          file = CubeFile(cube, cubes),
          line = CubeLine(cube, cubes) })
        .OrderByDescending(cube => cube.line)
        .ThenBy(cube => cube.file)
        .Select(cube => cube.name);
      Console.Write(string.Join(", ", result));
