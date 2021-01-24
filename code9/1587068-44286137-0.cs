                var res = (from p in ctx.Projects
                           let v = ctx.Versions.FirstOrDefault(x => p.Versions.Any(v => v.Id == x.Id))
                           where p.Id == projectId
                        select new Project
                        {
                            Name = p.Name,
                            Type = p.Type,
                            Id = p.Id,
                            Versions = new List<ProjectVersion>()
                            {
                                new ProjectVersion
                                {
                                    Checksum    = v.Checksum,
                                    Description = v.Description,
                                    Version     = v.Version ,
                                    EntryPoints = new List<EntryPoint>(v.EntryPoints),
                                    Systems     = new List<System>(v.Systems)
                                }
                            }
                        });
                return res.FirstOrDefault()
