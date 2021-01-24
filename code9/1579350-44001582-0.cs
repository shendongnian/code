    public static class MyClass{
     public static string ResourceFor<T>(this HtmlHelper html, object key) {
        return new System.Resources.ResourceManager(typeof(T)).GetString(key.ToString());
     }
    }
