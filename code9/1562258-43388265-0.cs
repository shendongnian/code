    class Test
    {
        //...
        public static readonly Empty =new Test();
    }
    var item = list2.FirstOrDefault(x => x.Key == myKey) ?? Test.Empty;
    var bla4 = item.Value;
