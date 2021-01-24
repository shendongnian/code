    class Player
    {
        public string First_name { get; set; }
        public string middle_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string Nationality_long { get; set; }
        public string Nationality_short { get; set; }
   
        public override string ToString()
        {
            return String.Format("Name: {0} {1} {2}, Birthday: {3}, Age: {4}, From: {5} / {6}",
                first_name,
                middle_name,
                last_name,
                birthday.ToShortDateString(),
                Age,
                nationality_long,
                nationality_short);
        }
    }
