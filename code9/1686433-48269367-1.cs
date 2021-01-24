    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TodoItem[] Todos { get; set; }
    }
    public class TodoItem
    {
        public string Todo { get; set; }
        public DateTime DueDate { get; set; }
    }
