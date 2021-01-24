    public class Repository
    {
         public Repository(FitaholicContext context)
         { }
    
         public async Task<Exercise> GetExercise(int id, bool includeRelated = false)
         { ... }
     }  
