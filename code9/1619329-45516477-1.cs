    class Animal
    {
        public string CommonProperty { get; set; }
    }
    class Dog : Animal
    {
        public string DogOnlyProperty { get; set; }
    }
    static class ExtensionMethods
    {
        static public T AnimalMethod<T>(this T o) where T : Animal
        {
            o.CommonProperty = "foo";
            return o;
        }
        static public T DogMethod<T>(this T o) where T : Dog
        {
            o.DogOnlyProperty = "bar";
            return o;
        }
    }
    class Example
    {
        static public void Test()
        {
            var dog = new Dog();
            dog.DogMethod().AnimalMethod(); // 1 - this works   
            dog.AnimalMethod().DogMethod(); // 2 - this works now
            Console.WriteLine("CommonProperty = {0}", dog.CommonProperty);
            Console.WriteLine("DogOnlyProperty = {0}", dog.DogOnlyProperty);
            var animal = new Animal();
            animal.AnimalMethod();
            //animal.DogMethod();                //Does not compile
            //animal.AnimalMethod().DogMethod(); //Does not compile
        }
    }
