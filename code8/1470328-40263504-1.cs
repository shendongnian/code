    var animalList = new List<AnimalModel>();
    ...
    var model = new AnimalModel();
    if (line.StartsWith("---") {
        model.Name = line;
    }
    else if(line.StartsWith("http://") {
        model.Url = line;
    }
    animalList.Add(model);
