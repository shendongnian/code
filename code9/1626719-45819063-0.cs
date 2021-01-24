    class Knight : Soldier
    {
        public Knight() : base()
        {
           base.level = 2;
        }
        public void Ride(string name)
        {
            Console.WriteLine(name + " can ride a mount");
        }
    }
