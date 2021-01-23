    public class TeacherEqualityComparer : IEqualityComparer<Teacher>
    {    
      public override bool Equals(Teacher x, Teacher y)
      {
          return x.Id == y.Id && x.Name == y.Name;
      }
    
      public override int GetHashCode((Teacher obj)
      {
         return obj == null ? 0 : obj.Id;
      }
    }
