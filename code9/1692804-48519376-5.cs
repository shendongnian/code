        public MyBaseClass CreateMyClass(MyEnum myEnum)
        {
            var dict = new Dictionary<MyEnum, Type>();
            dict.Add(MyEnum.Type1, typeof(MySubClass1));
            dict.Add(MyEnum.Type2, typeof(MySubClass2));
            var type = dict.Where(x => x.Key == myEnum).Select(x => x.Value);
            var instance = Activator.CreateInstance(type.GetType());
            return (MyBaseClass)instance;
        }
