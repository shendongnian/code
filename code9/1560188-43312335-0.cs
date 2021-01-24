    public MyModel GetBy(string property, string search)
    {
        switch (property) {
            case nameof(MyModel.Name):
                return GetByName(search);
            case nameof(MyModel.Url):
                return GetByUrl(search);
            default:
                throw new ArgumentException($"Unsupported property \"{property}\"");
        }
    }
