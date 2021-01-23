    class LinqUtil<T> where T : BaseClass
    {
        static void MyMain()
        {
            List<SubClassA> subClassAList = new List<SubClassA>
            {
                new SubClassA {SomeBoolValue = true, Value = 0},
                new SubClassA {SomeBoolValue = true, Value = 2},
                new SubClassA {SomeBoolValue = false, Value = 1},
            };
            List<SubClassB> subClassBList = new List<SubClassB>
            {
                new SubClassB {SomeDecimalValue = 1.3M, Value = 2},
                new SubClassB {SomeDecimalValue = 3.5M, Value = 1},
                new SubClassB {SomeDecimalValue = 0.2M, Value = 5},
            };
            IList<SubClassA> orderedAList = LinqUtil<SubClassA>.OrderList(subClassAList)
            .ToList();
            IList<SubClassB> orderedBList = LinqUtil<SubClassB>.OrderList(subClassBList)
            .ToList();
        }
        public static IEnumerable<T> OrderList(IEnumerable<T> list) 
        {
            return list.OrderBy(x => x.Value);
        }
    }
