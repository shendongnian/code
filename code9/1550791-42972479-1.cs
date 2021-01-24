    public class Service1 : IService1
    {
        private static Dictionary<string, ChatMember> members = new Dictionary<string, ChatMember>();
        public ChatMember Login(ChatMember member)
        {
            members.Add(member.Guid, member);
            return member;
        }
        public bool Logout(ChatMember member)
        {
            bool foundAndRemoved = members.Remove(member.Guid);
            return foundAndRemoved;
        }
    }
    [DataContract]
    public class ChatMember
    {
        [DataMember]
        public string Guid { get; set; }
        [DataMember]
        public string Name { get; set; }
        public ChatMember(string name)
        {
            Guid = new Guid().ToString();
            Name = name;
        }
    }
