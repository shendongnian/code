    class Ogre : Monster
    {
        public Ogre()
        {
            Hp = 50;
            Name = "Ogre";
        }
        public override void Attack()
        {
            Console.WriteLine("Ogre attacking!");
        }
    }
