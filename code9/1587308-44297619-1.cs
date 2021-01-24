    namespace Our.DAL.Implementations
    {
       public class CurrentStudentsRepository : DbAccess, IEntityAccess
       {
         // TEntityType shortened to TEntTyp 
         public IQueryable<Student> Query<Student>(Expression<Func<Student, bool>> query) 
         where Student: class
         {
           return Set<Student>().Where(student => student.IsRegistered).Where(query);
         }
       }
    }
