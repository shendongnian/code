    class Friend
    {
        public string friendUsername { get; set; }
        public int friendId { get; set; }
        // Add rest of properties here
        public override string ToString()
        {
            return "ID :" + friendId +  "\n Friend Name: " + friendUsername;
            // Append rest of properties here
        }
    }
