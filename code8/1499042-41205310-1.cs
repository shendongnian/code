        [Serializable()]
        public class User 
        {
            public string Fname { get; set; }
            public string Lname { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int Zip { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
    
            public User(string f, string l, string a, string c, string s, int z, string p, string e)
            {
                Fname = f;
                Lname = l;
                Address = a;
                City = c;
                State = s;
                Zip = z;
                Phone = p;
                Email = e;
            }
            public User() { }
        }
