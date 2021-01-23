    public class CallPointBaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CallPointDto : CallPointBaseDto
    {
        public List<UserBaseDto> Users { get; set; }
    }
    public class UserBaseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
    public class UserDto : UserBaseDto
    {
        public List<CallPointBaseDto> CallPoints { get; set; }
    }
