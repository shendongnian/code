    public static T Do<T>(this T obj, params Action<T>[] actions)
    {
        foreach(var action in actions)
            action(obj);
        return obj;
    }
...
    getForm().Do(f => f.Show()).Do(f => f.BringToFront());
