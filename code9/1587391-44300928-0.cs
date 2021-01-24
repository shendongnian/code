        var data = new MyData() { Age = 27, Name = "Ali" };
        var dataType = typeof(MyData);
        var obj = JsonConvert.DeserializeObject<MyData>(richTextBox1.Text);
        var binding = BindingFlags.Instance | BindingFlags.Public;
        var properties = obj.GetType().GetProperties(binding);
        foreach (var property in properties)
        {
            if (!property.CanRead)
                continue;
            var value = property.GetValue(obj);
            if (ReferenceEquals(value, null))
                continue;
            dataType.GetProperty(property.Name).SetValue(data, value);
        }
