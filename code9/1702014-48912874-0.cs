    abstract class Member
    {
        private List<Group> Groups { get; } = new List<Group>();
        internal void AddGroup(Group group)
        {
            Groups.Add(group);
        }
    }
    abstract class Group
    {
        protected List<Member> Members { get; } = new List<Member>();
    }
    abstract class Group<TMember> :Group  where TMember : Member
    {
        void AddMember(TMember member)
        {
            Members.Add(member);
            member.AddGroup(this);
        }
    }
