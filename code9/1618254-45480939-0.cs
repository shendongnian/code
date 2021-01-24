    public static class Invoker
    {
        public static void Invoke<TClass>(string methodName, Dictionary<string, object> myParameterObject, TClass instance)
        {
            var method = typeof(TClass).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            var parameters = method.GetParameters().Select(parameter => myParameterObject.ContainsKey(parameter.Name) ? myParameterObject[parameter.Name] : null).ToArray();
            method.Invoke(instance, parameters);
        }
    }
