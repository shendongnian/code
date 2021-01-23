    var strings = new[] { "State", "Name", "Location" };
    var result = _unityOfWork.TestRepository.GetAll().AsQueryable();
    // you may need to tweak the above before it works
    foreach (var field in strings)
    {
        switch (field)
        {
            case "State":
                result = result.Where(x => x.State == "OK");
                break;
            case "Name":
                result = result.Where(x => x.Name == "OK");
                break;
            case "Location":
                result = result.Where(x => x.Location == "OK");
                break;
        }
    }
    return result;   // if needed, add .ToList() or .ToArray() 
