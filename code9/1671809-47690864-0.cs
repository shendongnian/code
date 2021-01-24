    interface IPersonData
    {
        public int tech_id {get;}
        public string username {get;}
        ...
    }
    class Teacher : IPersonData {...}
    class Student : IPersonData {...}
