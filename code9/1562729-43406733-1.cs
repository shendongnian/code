    public static Task LongOperationAsync(List<String> names, Action<String, String> progress, string id)
    {
        return Task.Factory.StartNew(() =>
       {
           foreach (var item in names)
           {
               // do some long operation
               progress(item.ToUpper(), id);
           }
       });
    }
