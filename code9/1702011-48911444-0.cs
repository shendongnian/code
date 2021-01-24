    abstract class Member
    {
        public IGroup<Member> group;
        public void Init(IGroup<Member> grp)
        {
            group = grp;
        }
    }
    interface IGroup<T> where T : Member
    {
        T member { get; set; }
    }
    abstract class Group<T> : IGroup<Member>
    {
        public Member member { get; set; }
        public void InitMember()
        {
            member.Init(this);
        }
    }
    class Student : Member { }
    class ClassRoom<T> : Group<Student> where T : Student { }
