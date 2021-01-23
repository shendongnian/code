    internal class Program
    {
        private static void Main(string[] args)
        {
            var oldStudents = GetStudentsOld();
            var newStudents = GetStudentsNew();
            Console.WriteLine("Using 'Except' with 'IEqualityComparer<Student>'");
            WriteDropOutsWithExcept(oldStudents, newStudents);
            Console.WriteLine();
            WriteNewStudentsWithExcept(oldStudents, newStudents);
            Console.WriteLine("********************************************************");
            Console.WriteLine();
            Console.WriteLine("Using 'Compare' linq with 'Key' selector");
            WriteDropOutsWithKey(oldStudents, newStudents);
            Console.WriteLine();
            WriteNewStudentsWithKey(oldStudents, newStudents);
            Console.WriteLine("********************************************************");
            Console.WriteLine();
            Console.WriteLine("Using 'Compare' linq with 'StrategyComparer<Student>'");
            WriteDropOutsWithStrategyComparer(oldStudents, newStudents);
            Console.WriteLine();
            WriteNewStudentsWithStrategyComparer(oldStudents, newStudents);
            Console.ReadKey();
        }
        private static void WriteDropOutsWithExcept(List<Student> oldStudents, List<Student> newStudents)
        {
            Console.WriteLine("Dropped from enrollment:");
            foreach (var student in oldStudents.Compare(newStudents, new StudentComparer()))
            {
                Console.WriteLine(student);
            }
        }
        private static void WriteNewStudentsWithExcept(List<Student> oldStudents, List<Student> newStudents)
        {
            Console.WriteLine("Added to enrollment:");
            foreach (var student in newStudents.Compare(oldStudents, new StudentComparer()))
            {
                Console.WriteLine(student);
            }
        }
        private static void WriteDropOutsWithKey(List<Student> oldStudents, List<Student> newStudents)
        {
            Console.WriteLine("Dropped from enrollment:");
            foreach (var student in oldStudents.Compare(newStudents, s => s.Id))
            {
                Console.WriteLine(student);
            }
        }
        private static void WriteNewStudentsWithKey(List<Student> oldStudents, List<Student> newStudents)
        {
            Console.WriteLine("Added to enrollment:");
            foreach (var student in newStudents.Compare(oldStudents, s => s.Id))
            {
                Console.WriteLine(student);
            }
        }
        private static void WriteDropOutsWithStrategyComparer(List<Student> oldStudents, List<Student> newStudents)
        {
            Console.WriteLine("Dropped from enrollment:");
            foreach (var student in oldStudents.Compare(newStudents, new StrategyComparer<Student, int>(k => k.Id)))
            {
                Console.WriteLine(student);
            }
        }
        private static void WriteNewStudentsWithStrategyComparer(List<Student> oldStudents, List<Student> newStudents)
        {
            Console.WriteLine("Added to enrollment:");
            foreach (var student in newStudents.Compare(oldStudents, new StrategyComparer<Student, int>(k => k.Id)))
            {
                Console.WriteLine(student);
            }
        }
        private class StudentComparer : IEqualityComparer<Student>
        {
            public bool Equals(Student x, Student y)
            {
                return x.Id == y.Id;
            }
            public int GetHashCode(Student obj)
            {
                return obj.Id.GetHashCode();
            }
        }
        private class StrategyComparer<TModel, TKey> : IStrategyComparer<TModel>
        {
            private readonly Func<TModel, TKey> _keySelector;
            public StrategyComparer(Func<TModel, TKey> keySelector)
            {
                _keySelector = keySelector;
            }
            public bool Equals(TModel x, TModel y)
            {
                return Equals(_keySelector(x), _keySelector(y));
            }
            public int GetHashCode(TModel obj)
            {
                return _keySelector(obj).GetHashCode();
            }
        }
    }
    internal interface IStrategyComparer<in TModel> : IEqualityComparer<TModel>
    {
    }
    public static class CollectionUtils
    {
        //  Compare using Linq
        public static IEnumerable<TModel> Compare<TModel, TKey>(this IEnumerable<TModel> source1,
            IEnumerable<TModel> source2, Func<TModel, TKey> key)
        {
            return source1.Where(model => !source2.Any(m => Equals(key(m), key(model))));
        }
        //  Compare using Except/Except with comparer
        public static IEnumerable<TModel> Compare<TModel>(this IEnumerable<TModel> source1, IEnumerable<TModel> source2,
            IEqualityComparer<TModel> comparer = null)
        {
            if (comparer == null)
            {
                return source1.Except(source2);
            }
            return source1.Except(source2, comparer);
        }
        //  Compare using Linq with StrategyComparer
        public static IEnumerable<TModel> Compare<TModel>(this IEnumerable<TModel> source1,
            IEnumerable<TModel> source2, IStrategyComparer<TModel> comparer) {
            return source1.Where(model => !source2.Any(m => comparer.Equals(model, m)));
        }
    }
