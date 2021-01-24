    public class MemberListViewModel
    {
        public List<string> MemberList { get; set; }
        public string MemberType { get; set; }
         
        public MemberListViewModel()
        {
           this.MemberList = new List<string>();
        }
    }
