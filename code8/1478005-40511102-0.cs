    await ctx.Education.AsNoTracking()
            .Where(e => e.EmployeeNumber == employeeNumber)
            .Select(e => new EducationDTO {
                    Id = e.EducationID,
                    StartDate =  DbFunctions.CreateDateTime(e.EducationEntryYear == 0 ? DateTime.Now.Year : e.EducationEntryYear, 1, 1, 0, 0, 0) ?? DateTime.Now,
                    EndDate = DbFunctions.CreateDateTime(e.EducationEntryYear == 0 ? DateTime.Now.Year : e.EducationEntryYear, 1, 1, 0, 0, 0),
            })
            .ToListAsync().ConfigureAwait(false);
