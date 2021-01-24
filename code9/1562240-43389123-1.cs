    List<EditionItem> master_list = context.Projects.Select(
                      x => x.ProjectEditions
                          .OrderByDescending(pe => pe.Id)
                          .FirstOrDefault())
                          .SelectMany(x => x.EditionItems).ToList();
