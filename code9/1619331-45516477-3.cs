    interface IPrivateAnimal
    {
        void AnimalMethod();
    }
    interface IPrivateDog
    {
        void DogMethod();
    }
    class Animal : IPrivateAnimal
    {
        protected virtual string CommonProperty { get; set; }
        void IPrivateAnimal.AnimalMethod()  //Won't show up in intellisense, which is what we want
        {
            this.CommonProperty = "plugh";
        }
    }
    class Dog : Animal, IPrivateDog
    {
        private string DogOnlyProperty { get; set; }
        void IPrivateDog.DogMethod()  //Won't show up in intellisense
        {
            this.DogOnlyProperty = "xyzzy";
        }
    }
    static class ExtensionMethods
    {
        static public T AnimalMethod<T>(this T o) where T : IPrivateAnimal
        {
            o.AnimalMethod();  //Just call the instance method
            return o;
        }
        static public T DogMethod<T>(this T o) where T : IPrivateDog
        {
            o.DogMethod();    //Just call the instance method
            return o;
        }
    }
    class Example
    {
        static public void Test()
        {
            var dog = new Dog();
            dog.DogMethod().AnimalMethod(); 
            dog.AnimalMethod().DogMethod(); 
            Console.WriteLine("CommonProperty = {0}", typeof(Dog).GetProperty("CommonProperty", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(dog));
            Console.WriteLine("DogOnlyProperty = {0}", typeof(Dog).GetProperty("DogOnlyProperty", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(dog));
        }
    }
