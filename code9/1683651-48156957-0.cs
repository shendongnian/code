    var viewModel = new ViewModel()
    {
        RatingCategory01 = "a",
        RatingCategory02 = "b",
        RatingCategory03 = "c"
    };
    var dictionaryModel = viewModel.GetType()
        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .ToDictionary(prop => prop.Name, prop => prop.GetValue(viewModel, null));
