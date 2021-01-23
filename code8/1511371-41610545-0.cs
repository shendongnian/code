    public static class SomeOtherClass
    {
        //extension method to the Dog class
        public static Dog Jump(this Dog dog)
        {
            Console.WriteLine("Dog Jumped");
            return dog;
        }
    }
