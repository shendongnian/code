    var modelType = typeof(CustomerEditViewModel);
    var properties = modelType.GetProperties();
    foreach (var property in properties) {
      var displayAttr = property.GetCustomAttribute<DisplayAttribute>();
      Console.WriteLine(string.Format("{0}->{1}", property.Name, displayAttr.Name));
    }
