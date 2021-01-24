    System.NullReferenceException occurred
      HResult=-2147467261
      Message=Object reference not set to an instance of an object.
      Source=Anonymously Hosted DynamicMethods Assembly
      StackTrace:
           at lambda_method(Closure , InspectionAsset )
           at System.Linq.Enumerable.<>c__DisplayClass6_0`1.<CombinePredicates>b__0(TSource x)
           at System.Linq.Enumerable.WhereListIterator`1.MoveNext()
           at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
           at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
           at AssetManagement.Model.Repositories.AssetDataService.<LoadOtherAssetsFromTrackAsset>d__18.MoveNext() in C:\src\AssetManagement\AssetManagement.Model\Repositories\AssetDataService.cs:line 135
      InnerException: 
