    class NormalUser
    {
        public NormalUser(User user, int age)
        {
            this.Name = user.name;
            this.Adress = user.Adress;
            // further properties defined in the base-class
           this.Age = age
           // further properties defined in NormalUser
        }
    }
