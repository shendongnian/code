    var myArray = (Activator.CreateInstance(typeof(List<>).MakeGenericType(typeof(string)),
        System.Reflection.BindingFlags.CreateInstance
        | System.Reflection.BindingFlags.Public
        | System.Reflection.BindingFlags.Instance
        | System.Reflection.BindingFlags.OptionalParamBinding,
        null,
        new[]
        {
            typeof(Enumerable).GetMethod("Cast")
                .MakeGenericMethod(typeof(string))
                .Invoke(null, new []
                {
                    (new[] { Activator.CreateInstance(typeof(string),
                    System.Reflection.BindingFlags.CreateInstance
                    | System.Reflection.BindingFlags.Public
                    | System.Reflection.BindingFlags.Instance
                    | System.Reflection.BindingFlags.OptionalParamBinding,
                    null,
                    new[] { "Test".ToCharArray() },
                    null)})
                })
        },
        null));
