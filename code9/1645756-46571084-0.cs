        public List<string> ExtractCommonPaths(List<string> paths)
        {
            var separatedImput = paths.Select(path => path.Split(new [] {":\\", "\\" }, StringSplitOptions.RemoveEmptyEntries));
            return separatedImput.GroupBy(path => path[0] + ":\\" + path[1])
                .Select(g =>
                {
                    var commonPath = g.Key;
                    var commpoPathLength = 2;
                    for (;;)
                    {
                        var exit = false;
                        var pathItem = string.Empty;
                        foreach (var path in g)
                        {
                            if (path.Length <= commpoPathLength)
                            {
                                exit = true;
                                break;
                            }
                            if (pathItem == string.Empty)
                                pathItem = path[commpoPathLength];
                            else
                            {
                                if (pathItem != path[commpoPathLength])
                                {
                                    exit = true;
                                    break;
                                }
                            }
                        }
                        if (exit)
                            break;
                        commonPath += "\\" + pathItem;
                        commpoPathLength++;
                    }
                    return commonPath;
                })
                .ToList();
        }
