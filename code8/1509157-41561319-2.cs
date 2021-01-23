    public class Character
    {
        public string Name { get; set; }
        public int BaseAttack { get; set; }
        public int Health { get; set; }
        public int Age { get; set; }
        public int SaiyanLevel { get; set; }
        public Character(string _mName, int _mBaseAttack, int _mHealth, int _mAge, int _mSaiyanLevel)
        {
            //Initializing my member varaibles
            Name = _mName;
            BaseAttack = _mBaseAttack;
            Health = _mHealth;
            Age = _mAge;
            SaiyanLevel = _mSaiyanLevel;
        }
        // The default constructor is just initializing a local variable userCharacter 
        // to a new Character() that will be destroyed once it goes out of scope. 
        // If you need some default initialization
        // you could do: 
        public Character() : this(string.Empty, -1, -1, -1, -1) { }
        // I've initialized all int fields to -1 since it's a value
        // that none of these fields (hopefully) should ever have
        // Original default constructor
        //public Character()
        //{
        //   Character userCharacter = new Character();
        //   Once the code reaches the } below, userCharacter will
        //   be destroyed
        //}
        // Overrode the ToString method so that you can print
        // the characters to the console
        public override string ToString()
        {
            return string.Concat("Character Name: ", Name, " Base Attack: ", BaseAttack, " Health: ", Health, " Age: ", Age, " Saiyan Level: ", SaiyanLevel);
        }
    }
