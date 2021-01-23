       public async Task<IEnumerable<TestType>> SaveTestTypesAsync(List<TestType> testTypes, int schoolyearId, int schoolclassId, int subjectId)
            {
                var testTypesFromDatabase = await context.TestTypes
                                              .Include(t => t.Subject)
                                              .Include(s => s.Schoolclass)
                                              .Where(p =>
                                              p.Schoolclass.Id == schoolclassId &&
                                              p.Subject.Id == subjectId)
                                              .AsNoTracking()
                                              .ToListAsync();
    
                var schoolclass = new Schoolclass { Id = schoolclassId };
                var subject = new Subject { Id = subjectId };
                var schoolyear = new Schoolyear { Id = schoolyearId };
    
                // Make the navigation properties available during SaveChanges()
                context.Attach(schoolclass);
                context.Attach(subject);
                context.Attach(schoolyear);
    
                // DELETE
                var testTypesToRemove = testTypesFromDatabase.Except(testTypes, new TestTypeComparer()).ToList();
                context.TestTypes.RemoveRange(testTypesToRemove);
    
                // ADD
                var testTypesToAdd = testTypes.Where(t => t.Id == 0).ToList();  // 
                foreach (var testType in testTypesToAdd)
                {
                    testType.Schoolclass = schoolclass;
                    testType.Subject = subject;
                    testType.Schoolyear = schoolyear;
                }
                context.TestTypes.AddRange(testTypesToAdd);
    
                // UPDATE
                var modifiedTestTypesToUpdate = testTypes.Except(testTypesToAdd.Concat(testTypesToRemove).ToList(), new TestTypeComparer()).ToList();
                foreach (var testType in modifiedTestTypesToUpdate)
                {
                    testType.Schoolclass = schoolclass;
                    testType.Subject = subject;
                    testType.Schoolyear = schoolyear;
                }   
                context.UpdateRange(modifiedTestTypesToUpdate);
    
                await context.SaveChangesAsync();
    
                return await this.GetTestTypesConfigurationAsync(schoolclassId, subjectId);
            }
