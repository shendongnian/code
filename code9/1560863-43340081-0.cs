    static void Main(string[] args)
        {
            List<MyClass> inputlist = new List<MyClass>();
            inputlist.Add(new MyClass { GroupName = "A", Value = 10 });
            inputlist.Add(new MyClass { GroupName = "A", Value = 15 });
            inputlist.Add(new MyClass { GroupName = "A", Value = 20 });
            inputlist.Add(new MyClass { GroupName = "B", Value = 1 });
            inputlist.Add(new MyClass { GroupName = "B", Value = 10 });
            inputlist.Add(new MyClass { GroupName = "B", Value = 15 });
            inputlist.Add(new MyClass { GroupName = "C", Value = 5 });
            inputlist.Add(new MyClass { GroupName = "C", Value = 10 });
            inputlist.Add(new MyClass { GroupName = "C", Value = 15 });
            List<MyClass> outputlist = new List<MyClass>();
            foreach (var item in 
                    inputlist.GroupBy(x => x.GroupName).Select(x => new MyClass
                    {
                        GroupName = x.First().GroupName,
                        Value = x.Min().Value
                    }).ToList().OrderBy(x => x.Value))
            {
                outputlist.AddRange(inputlist.Where(x => x.GroupName == item.GroupName));
            }
            foreach (var item in outputlist)
            {
                Console.WriteLine(item.GroupName + " " + item.Value);
            }
            Console.ReadLine();
        }
    }
    public class MyClass : IComparable
    {
        public string GroupName { get; set; }
        public int Value { get; set; }
        public int CompareTo(object value)
        {
            int val = (int)Value;
            if (this.Value > val) return -1;
            if (this.Value == val) return 0;
            return 1;
        }
    }
