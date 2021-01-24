csharp
public static class FormCollectionExtensions
{
    /// <summary>
    /// Attempts to bind a form collection to a model of type <typeparamref name="T" />.
    /// </summary>
    /// <typeparam name="T">The model type. Must have a public parameterless constructor.</typeparam>
    /// <param name="form">The form data to bind.</param>
    /// <returns>A new instance of type <typeparamref name="T" /> containing the form data.</returns>
    public static T BindToModel<T>(this IFormCollection form) where T : new()
    {
        var props = typeof(T).GetProperties();
        var instance = Activator.CreateInstance<T>();
        var formKeyMap = form.Keys.ToDictionary(k => k.ToUpper(), k => k);
        foreach (var p in props)
        {
            if (p.CanWrite && formKeyMap.ContainsKey(p.Name.ToUpper()))
            {
                p.SetValue(instance, form[formKeyMap[p.Name.ToUpper()]].FirstOrDefault());
            }
        }
        return instance;
    }
}
This will attempt to bind an `IFormCollection` to whatever model type you pass in. Property names are case insensitive (i.e. you can map `firstname=Bob` to `public string FirstName { get; set; }`.
Usage:
csharp
var myModel = (await httpReq.ReadFormAsync()).BindToModel<MyModel>();
