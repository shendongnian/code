    In controller  you can do like this  .I tested with console application.
        using (var ctx = new SampleDbContext())
            {
                var mat = new Material
                {
                    Name = "A",
                    Project = new List<Project> {new Project {Name = "P1", Date = DateTime.Now}}
                };
                ctx.Materials.Add(mat);
                ctx.SaveChanges();
            }
