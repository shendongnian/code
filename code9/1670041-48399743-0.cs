    abstract class LivingEntity
    {
        public int Health
        {
            get;
            protected set;
        }
    
    
        protected LivingEntity(int health)
        {
            this.Health = health;
        }
    }
    
    class Person : LivingEntity
    {
        public Person() : base(100)
        { }
    }
    
    class Dog : LivingEntity
    {
        public Dog() : base(50)
        { }
    }
