        public class YourType
        {
            public List<int> Prop1 { get; set; }
            public List<int> Prop2 { get; set; }
        }
        public static YourType Method2(int[] array, int number)
        {
            return new YourType { Prop1 = list1, Prop2 = list2 };
        }
