    public async Task ToDoAsync(string file)
    {
        using (var fileReader = File.OpenText(file))
        {
            var allFile = await fileReader.ReadToEndAsync();
            // and do something
        }
    }
