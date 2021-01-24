    public async Task<int> UpdateProMetrixRiskAsync(Student student)
    {
            PreSchoolContext.AddOrUpdateEntity<Student>(PreSchoolContext, student); //This one resolved issue of unit test and works fine in real scenario too.
            var result = await PreSchoolContext.SaveChangesAsync().ConfigureAwait(false);
            return result;
    }
    
