    var items = js.ExecuteScript("return angular.element(document.getElementById('bank-list')).scope().items") as ReadOnlyCollection<object>;
    if(items != null)
    {
        foreach (obj obj in items)
        {
            Dictionary<string,object> dict = obj as Dictionary<string, object>;
            if (dict != null)
            {
                 foreach(var val in dict.Values)
                     Console.WriteLine(val);
            }
        }
    }
