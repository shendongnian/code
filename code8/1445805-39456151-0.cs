    ERROR 2016-09-12 16:09:28,695 890063ms Util                   Package_Read            
    At least one object must implement IComparable
    ERROR 2016-09-12 16:09:28,696 890064ms Util                   Package_Read          - mscorlib
    ERROR 2016-09-12 16:09:28,697 890065ms Util                   Package_Read            
    at System.Collections.Comparer.Compare(Object a, Object b)
    at System.Collections.Generic.ObjectComparer`1.Compare(T x, T y)
    at System.Linq.EnumerableSorter`2.CompareKeys(Int32 index1, Int32 index2)
    at System.Linq.EnumerableSorter`2.CompareKeys(Int32 index1, Int32 index2)
    at System.Linq.EnumerableSorter`1.QuickSort(Int32[] map, Int32 left, Int32 right)
    at System.Linq.EnumerableSorter`1.Sort(TElement[] elements, Int32 count)
    at System.Linq.OrderedEnumerable`1.<GetEnumerator>d__1.MoveNext()
    at System.Linq.Enumerable.<SkipIterator>d__30`1.MoveNext()
    at Kendo.Mvc.Extensions.QueryableExtensions.Execute[TModel,TResult](IQueryable source, Func`2 selector)
    at Kendo.Mvc.Extensions.QueryableExtensions.CreateDataSourceResult[TModel,TResult](IQueryable queryable, DataSourceRequest request, ModelStateDictionary modelState, Func`2 selector)
    at Kendo.Mvc.Extensions.QueryableExtensions.ToDataSourceResult(IQueryable queryable, DataSourceRequest request, ModelStateDictionary modelState)
    at Kendo.Mvc.Extensions.QueryableExtensions.ToDataSourceResult(IQueryable enumerable, DataSourceRequest request)
    at Kendo.Mvc.Extensions.QueryableExtensions.ToDataSourceResult(IEnumerable enumerable, DataSourceRequest request)
