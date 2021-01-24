    public class MemberInformationParameter
    {
        public MemberInformationParameter(Member member)
        {
                Username = member.Username;
                Password = member.Password;
                Email = member.MemberInfo.Email;
                City = member.MemberInfo.City;
                State = member.MemberInfo.State;
                BirthDate = member.MemberInfo.BirthDate;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime BirthDate { get; set; }
    }
