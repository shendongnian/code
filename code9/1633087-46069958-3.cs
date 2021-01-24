    public class TestCompare
    {
        public void test ()
        {
            var myArray = new MyClass[]
            {
                new MyClass { id = 1, name = "A" },
                new MyClass { id = 2, name = "B" },
                new MyClass { id = 3, name = "C" },
                new MyClass { id = 4, name = "D" },
                new MyClass { id = 5, name = "E" },
                new MyClass { id = 6, name = "F" },
            };
            var myArray2 = new MyClass[]
            {
                new MyClass { id = 1, name = "A" },
                new MyClass { id = 2, name = "B" },
                new MyClass { id = 0, name = "X" },
                new MyClass { id = 3, name = "C" },
                new MyClass { id = 4, name = "D" },
                new MyClass { id = 23, name = "Z"},
                new MyClass { id = 5, name = "E" },
                new MyClass { id = 6, name = "F" },
            };
            var sortList = new List<int> { 2, 3, 1, 4, 5, 6 };
            
            // good order
            var mySortedArray = myArray.OrderBy(x => x.id, new MySpecialComparer(sortList)).ToList(); 
            // good order with elem id 0 and 23 at the end
            var mySortedArray2 = myArray2.OrderBy(x => x.id, new MySpecialComparer(sortList)).ToList();
        }
    }
    public class MyClass
    {
        public int id;
        public string name;
    }
