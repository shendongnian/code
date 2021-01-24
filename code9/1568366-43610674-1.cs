    interface ICommonSchoolProperties
    {
        public int Id {get;}           // primary key
        public string Name {get;}
    }
    public class Teacher : ICommonSchoolProperties {...}
    public class ClassRoom : ICommonSchoolProperties {...}
    etc.
