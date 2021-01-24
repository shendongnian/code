    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Type1 {
        public int Id { get; set; }
        public int Value { get; set; }
    }
    public class Type2 {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ForeignKeyTo1 { get; set; }
    }
    public class Type3 {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ForeignKeyTo2 { get; set; }
    }
    public class Program {
        public static void Main() {
            //Data
            var list1 = new List<Type1>() {
                new Type1 { Id = 1, Value = 1 },
                new Type1 { Id = 2, Value = 2 },
                new Type1 { Id = 3, Value = 3 }
                //4 is missing
            };
            var list2 = new List<Type2>() {
                new Type2 { Id = 1, Value = "1", ForeignKeyTo1 = 1 },
                new Type2 { Id = 2, Value = "2", ForeignKeyTo1 = 2 },
                //3 is missing
                new Type2 { Id = 4, Value = "4", ForeignKeyTo1 = 4 }
            };
            var list3 = new List<Type3>() {
                new Type3 { Id = 1, Value = "1", ForeignKeyTo2 = 1 },
                //2 is missing
                new Type3 { Id = 3, Value = "2", ForeignKeyTo2 = 2 },
                new Type3 { Id = 4, Value = "4", ForeignKeyTo2 = 4 }
            };
            var joinSpecs = new IJoinSpecification[] {
                JoinSpecification.Create(list1, list2, v1 => v1.Id, v2 => v2.ForeignKeyTo1, JoinType.Inner),
                JoinSpecification.Create(list2, list3, v2 => v2.Id, v3 => v3.ForeignKeyTo2, JoinType.LeftOuter)
            };
            //Creating LINQ query
            IEnumerable<Dictionary<object, object>> result = null;
            foreach (var joinSpec in joinSpecs) {
                result = joinSpec.PerformJoin(result);
            }
            //Executing the LINQ query
            var finalResult = result.ToList();
            //This is just to illustrate how to get the final projection columns
            var resultWithColumns = (
                from row in finalResult
                let item1 = row.GetItemFor(list1)
                let item2 = row.GetItemFor(list2)
                let item3 = row.GetItemFor(list3)
                select new {
                    Id1 = item1?.Id,
                    Id2 = item2?.Id,
                    Id3 = item3?.Id,
                    Value1 = item1?.Value,
                    Value2 = item2?.Value,
                    Value3 = item3?.Value
                }).ToList();
            foreach (var row in resultWithColumns) {
                Console.WriteLine(row.ToString());
            }
            //Outputs:
            //{ Id1 = 1, Id2 = 1, Id3 = 1, Value1 = 1, Value2 = 1, Value3 = 1 }
            //{ Id1 = 2, Id2 = 2, Id3 = 3, Value1 = 2, Value2 = 2, Value3 = 2 }
        }
    }
    public static class RowDictionaryHelpers {
        public static IEnumerable<Dictionary<object, object>> CreateFrom<T>(IEnumerable<T> source) where T : class {
            return source.Select(item => new Dictionary<object, object> { { source, item } });
        }
        public static T GetItemFor<T>(this Dictionary<object, object> dict, IEnumerable<T> key) where T : class {
            return dict[key] as T;
        }
        public static Dictionary<object, object> WithAddedItem<T>(this Dictionary<object, object> dict, IEnumerable<T> key, T item) where T : class {
            var result = new Dictionary<object, object>(dict);
            result.Add(key, item);
            return result;
        }
    }
    public interface IJoinSpecification {
        IEnumerable<Dictionary<object, object>> PerformJoin(IEnumerable<Dictionary<object, object>> sourceData);
    }
    public enum JoinType {
        Inner = 1,
        LeftOuter = 2
    }
    public static class JoinSpecification {
        public static JoinSpecification<TLeft, TRight, TKeyType> Create<TLeft, TRight, TKeyType>(IEnumerable<TLeft> LeftTable, IEnumerable<TRight> RightTable, Func<TLeft, TKeyType> LeftKeySelector, Func<TRight, TKeyType> RightKeySelector, JoinType JoinType) where TLeft : class where TRight : class {
            return new JoinSpecification<TLeft, TRight, TKeyType> {
                LeftTable = LeftTable,
                RightTable = RightTable,
                LeftKeySelector = LeftKeySelector,
                RightKeySelector = RightKeySelector,
                JoinType = JoinType,
            };
        }
    }
    public class JoinSpecification<TLeft, TRight, TKeyType> : IJoinSpecification where TLeft : class where TRight : class {
        public IEnumerable<TLeft> LeftTable { get; set; } //Must already exist
        public IEnumerable<TRight> RightTable { get; set; } //Newly joined table
        public Func<TLeft, TKeyType> LeftKeySelector { get; set; }
        public Func<TRight, TKeyType> RightKeySelector { get; set; }
        public JoinType JoinType { get; set; }
        public IEnumerable<Dictionary<object, object>> PerformJoin(IEnumerable<Dictionary<object, object>> sourceData) {
            if (sourceData == null) {
                sourceData = RowDictionaryHelpers.CreateFrom(LeftTable);
            }
            return
                from joinedRowsObj in sourceData
                join rightRow in RightTable
                    on joinedRowsObj.GetItemFor(LeftTable).ApplyIfNotNull(LeftKeySelector) equals rightRow.ApplyIfNotNull(RightKeySelector)
                    into rightItemsForLeftItem
                from rightItem in rightItemsForLeftItem.DefaultIfEmpty()
                where JoinType == JoinType.LeftOuter || rightItem != null
                select joinedRowsObj.WithAddedItem(RightTable, rightItem)
            ;
        }
    }
    public static class FuncExtansions {
        public static TResult ApplyIfNotNull<T, TResult>(this T item, Func<T, TResult> func) where T : class {
            return item != null ? func(item) : default(TResult);
        }
    }
