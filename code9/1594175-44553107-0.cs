        private ApplicationDbContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var programs = new List<Context.Models.Program>
            {
                new Context.Models.Program
                {
                    CreatedBy = "d0806514-cbce-47b7-974f-c50f77d5e89c",
                    CreatedDate = new DateTime(2010, 10, 10),
                    Id = 98,
                    IsActive = true,
                    IsDeleted = false,
                    Length = 1,
                    ModifiedBy = "d0806514-cbce-47b7-974f-c50f77d5e89c",
                    ModifiedDate = new DateTime(2010, 10, 10),
                    Name = "Big Muscle",
                    TimesPerWeek = 1
                },
                new Context.Models.Program
                {
                    CreatedBy = "d0806514-cbce-47b7-974f-c50f77d5e89c",
                    CreatedDate = new DateTime(2010, 10, 10),
                    Id = 99,
                    IsActive = true,
                    IsDeleted = false,
                    Length = 1,
                    ModifiedBy = "d0806514-cbce-47b7-974f-c50f77d5e89c",
                    ModifiedDate = new DateTime(2010, 10, 10),
                    Name = "Stay Fit",
                    TimesPerWeek = 1
                }
            };
            context.AddRange(programs);
            context.SaveChanges();
            return context;
        }
