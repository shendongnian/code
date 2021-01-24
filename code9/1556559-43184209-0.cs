    public class Animal
    {
        public void WhatAmI()
        {
            Console.WriteLine("Animal");
        }
    }
    
    public class Fish : Animal
    {
        public new void WhatAmI()
        {
            base.WhatAmI();
            Console.WriteLine("Fish");
        }
    }
    
    public class HammerheadShark : Fish
    {
        public new void WhatAmI()
        {
            base.WhatAmI();
            Console.WriteLine("HammerheadShark");
        }
    }
