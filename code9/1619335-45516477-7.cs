    interface IPrivateAnimal
    {
        Animal AnimalMethod();
    }
    interface IPrivateDog
    {
        Dog DogMethod();
    }
    class Animal : IPrivateAnimal
    {
        protected virtual string CommonProperty { get; set; }  //notice this is nonpublic now
        Animal IPrivateAnimal.AnimalMethod()  //Won't show up in intellisense, as intended
        {
            this.CommonProperty = "plugh";
            return this;
        }
    }
    class Dog : Animal, IPrivateDog
    {
        private string DogOnlyProperty { get; set; }  //notice this is nonpublic now
        Dog IPrivateDog.DogMethod()  //Won't show up in intellisense
        {
            this.DogOnlyProperty = "xyzzy";
            return this;
        }
    }
    static class ExtensionMethods
    {
        static public T AnimalMethod<T>(this T o) where T : class, IPrivateAnimal
        {
            return o.AnimalMethod() as T;
        }
        static public T DogMethod<T>(this T o) where T : class, IPrivateDog
        {
            return o.DogMethod() as T;
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
