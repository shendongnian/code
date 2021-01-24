    class LoginRecord {
        public string Person {get;}
        public DateTime Login {get;}
        public DateTime Logout {get;}
        public LoginRecord(string person, string date, string login, string logout) {
            ... // Parse strings to make fields of appropriate types
        }
        public LoginRecord(string person, DateTime login, DateTime logout) {
            if (login.Date != logout.Date) {
                throw new ArgumentException(nameof(logout));
            }
            Person = person;
            Login = login;
            Logout = logout;
        }
    }
