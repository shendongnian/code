    // This is the base list - it just requires something to populate it.
    public class IntegerList : List<int>
    {
        public IntegerList(IIntegerListPopulator populator, int size)
        {
            populator.PopulateList(this, size);
        }
    }
    // Interface and implementation to populate a list with random numbers.
    public interface IIntegerListPopulator
    {
        void PopulateList(List<int> target, int size);
    }
    public class RandomIntegerListPopulator : IIntegerListPopulator
    {
        public void PopulateList(List<int> target, int size)
        {
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                target.Add(random.Next(0, 100));
            }
        }
    }
    // Compares by values, but the populator is injected - needed so that
    // the class can be tested.
    public class IntegerListThatComparesByValues : IntegerList, IComparable<IntegerListThatComparesByValues>
    {
        public IntegerListThatComparesByValues(IIntegerListPopulator populator, int size)
            : base(populator, size)
        { }
        public int CompareTo(IntegerListThatComparesByValues other)
        {
            return new IntegerListValueComparer().Compare(this, other);
        }
    }
    // Class to perform comparisons by value. There's no real point 
    // in implementing IComparer since I'm not using it that way,
    // but it doesn't hurt.
    public class IntegerListValueComparer : IComparer<IntegerList>
    {
        public int Compare(IntegerList x, IntegerList y)
        {
            // I made this part up. I don't actually know how
            // you want to handle nulls. 
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            // Always compare the longer one to the shorter.
            // if this one is shorter, do the reverse comparison
            // and reverse the result.
            if (y.Count < x.Count) return -Compare(y, x);
            if (x.SequenceEqual(y)) return 0;
            for (var index = 0; index < x.Count; index++)
            {
                var comparison = x[index].CompareTo(y[index]);
                if (comparison != 0) return comparison;
            }
            
            // If the other list is longer than this one, then assume
            // that the next element of this list is 0.  
            return -y[x.Count];
        }
    }
    public class IntegerListThatComparesByLength : IntegerList, IComparable<IntegerListThatComparesByLength>
    {
        public IntegerListThatComparesByLength(IIntegerListPopulator populator, int size)
            : base(populator, size)
        {
        }
        public int CompareTo(IntegerListThatComparesByLength other)
        {
            var comparisonByCount = Count.CompareTo(other?.Count ?? 0);
            return comparisonByCount != 0
                ? comparisonByCount
                : new IntegerListValueComparer().Compare(this, other);
        }
    }
    // *************************************************************
    // These are the concrete classes specified in the requirements.
    // *************************************************************
    public class RandomIntegerListThatComparesByValues : 
        IntegerListThatComparesByValues
    {
        public RandomIntegerListThatComparesByValues(int size)
            : base(new RandomIntegerListPopulator(), size)
        { }
    }
    public class RandomIntegerListThatComparesByLength : 
        IntegerListThatComparesByLength
    {
        public RandomIntegerListThatComparesByLength(int size)
            : base(new RandomIntegerListPopulator(), size)
        { }
    }
    // *************************************************************
    // The rest is all testing.
    // *************************************************************
    // Allows me to create class instances that contain the numbers
    // I specify instead of random numbers so that I can create 
    // test cases.
    public class IntegerListPopulatorTestDouble : IIntegerListPopulator
    {
        private readonly int[] _values;
        public IntegerListPopulatorTestDouble(params int[] values)
        {
            _values = values;
        }
        public void PopulateList(List<int> target, int size)
        {
            target.AddRange(_values.Take(size));
        }
    }
    [TestClass]
    public class IntegerListThatComparesByValuesTests
    {
        [TestMethod]
        public void EmptyListsAreEqual()
        {
            var list1 = new IntegerListThatComparesByValues(new IntegerListPopulatorTestDouble(), 0 );
            var list2 = new IntegerListThatComparesByValues(new IntegerListPopulatorTestDouble(), 0);
            Assert.AreEqual(0, list1.CompareTo(list2));
        }
        [TestMethod]
        public void ListsWithSameValuesAreEqual()
        {
            var list1 = new IntegerListThatComparesByValues(new IntegerListPopulatorTestDouble(1,2,3), 3);
            var list2 = new IntegerListThatComparesByValues(new IntegerListPopulatorTestDouble(1,2,3), 3);
            Assert.AreEqual(0, list1.CompareTo(list2));
        }
        [TestMethod]
        public void ListsOfSameLengthComparedByFirstNonEqualValue()
        {
            var list1 = new IntegerListThatComparesByValues(new IntegerListPopulatorTestDouble(1, 2, 4), 3);
            var list2 = new IntegerListThatComparesByValues(new IntegerListPopulatorTestDouble(1, 2, 3), 3);
            Assert.IsTrue(list1.CompareTo(list2) > 0);
        }
        [TestMethod]
        public void MissingElementsOfListAreSortedAsZeros()
        {
            var list1 = new IntegerListThatComparesByValues(new IntegerListPopulatorTestDouble(1, 2, 3, 4), 4);
            var list2 = new IntegerListThatComparesByValues(new IntegerListPopulatorTestDouble(1, 2, 3), 3);
            var comparison = list1.CompareTo(list2);
            Assert.IsTrue(comparison > 0);
            comparison = list2.CompareTo(list1);
            Assert.IsTrue(comparison < 0);
        }
        [TestMethod]
        public void MissingElementsOfListAreSortedAsZeros_Case2()
        {
            var list1 = new IntegerListThatComparesByValues(new IntegerListPopulatorTestDouble(1, 2, 3, -4), 4);
            var list2 = new IntegerListThatComparesByValues(new IntegerListPopulatorTestDouble(1, 2, 3), 3);
            Assert.IsTrue(list1.CompareTo(list2) < 0);
            Assert.IsTrue(list2.CompareTo(list1) > 0);
        }
    }
    [TestClass]
    public class IntegerListThatComparesByLengthTests
    {
        [TestMethod]
        public void ListsAreComparedByLength()
        {
            var list1 = new IntegerListThatComparesByLength(new IntegerListPopulatorTestDouble(1, 2, 3, 4), 4);
            var list2 = new IntegerListThatComparesByLength(new IntegerListPopulatorTestDouble(1, 2, 3), 3);
            Assert.IsTrue(list1.CompareTo(list2) > 0);
            Assert.IsTrue(list2.CompareTo(list1) < 0);
        }
        [TestMethod]
        public void ListsOfEqualLengthAreComparedByValue()
        {
            var list1 = new IntegerListThatComparesByLength(new IntegerListPopulatorTestDouble(1, 2, 4), 3);
            var list2 = new IntegerListThatComparesByLength(new IntegerListPopulatorTestDouble(1, 2, 3), 3);
            Assert.IsTrue(list1.CompareTo(list2) > 0);
            Assert.IsTrue(list2.CompareTo(list1) < 0);
        }
    }
