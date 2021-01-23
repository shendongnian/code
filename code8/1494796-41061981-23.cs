      var result = cubes
        .Select (cube => new {
          name = cube.Substring(0, cube.IndexOf('|')),
          file = CubeFile(cube, cubes),
          line = CubeLine(cube, cubes) })
        .OrderBy(cube => cube.line)
        .Select(cube => cube.name);  
