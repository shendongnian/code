        var JSONCovert = typeof(JsonConvert);
        var parameterTypes = new[] { typeof(string) };
        var deserializer = JSONCovert.GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(i => i.Name.Equals("DeserializeObject", StringComparison.InvariantCulture))
            .Where(i => i.IsGenericMethod)
            .Where(i => i.GetParameters().Select(a => a.ParameterType).SequenceEqual(parameterTypes))
            .Single();
