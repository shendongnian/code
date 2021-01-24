        interface IMyclass{}
        class MyType1 : IMyclass {}
        
        class MyType2 : IMyclass {}
        public class SomeClass
        {
            private List<IMyclass> MyList = new List<IMyclass>();
            public void DoSomething()
            {
                MyList.AddRange(new List<IMyclass> { new MyType1(), new MyType1() });
                MyList.AddRange(new List<IMyclass> { new MyType2(), new MyType2() });
            }
        }
