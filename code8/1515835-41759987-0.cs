            var context = new SampleDbContext();
            var candidates = context.Candidates
                .Include("SkillSets").ToList();
            foreach (var candidate in candidates)
            {
                foreach (var sk in candidate.SkillSets.Where(  s1 => s1.Candidates.Count(c=>c.id == candidate.id)>0 ))
                {
                    Console.WriteLine( string.Format(@" Name : {0} Skill :{1}",candidate.Firstname ,sk.Name )  );
                }
            }
