    public class Comparer : IEqualityComparer<ProgramInfo>
    {
       public bool Equals(ProgramInfo x, ProgramInfo y)
       {
          return x.Name == y.Name &&
                 x.ProgramId == y.ProgramId &&
                 x.Description == y.Description;
       }
       public int GetHashCode(ProgramInfo obj)
       {
          return obj.Name.GetHashCode() ^
                 obj.ProgramId.GetHashCode() ^
                 obj.Description.GetHashCode();
       }
    }
    var thirdList = firstList.Intersect(secondList, new Comparer());
