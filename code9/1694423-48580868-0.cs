            public class TestClass{
               public int value;
            }
            
            ...
            List<TestClass> mainList = new List<TestClass>();
            List<TestClass> subList = new List<TestClass>();
            mainList.Add(new TestClass { value = 5 });
            subList.Add(mainList[0]);
            Console.WriteLine("{0}", mainList[0].value);
            Console.WriteLine("{0}", subList[0].value);
            subList[0].value++;
            Console.WriteLine("{0}", mainList[0].value);
            Console.WriteLine("{0}", subList[0].value);
            mainList[0].value+=2;
            Console.WriteLine("{0}", mainList[0].value);
            Console.WriteLine("{0}", subList[0].value);
