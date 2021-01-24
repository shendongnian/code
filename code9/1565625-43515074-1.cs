    // passed as parameters
    int age;
    string name;
    bool sortByName;
    
    var persons = _dbContext.Person;
    
    // always filter by Age
    var result = persons.Where(p => p.Age > age);
    
    // additionally filter by Name if some condition is met
    if (age > 25) {
        result = result.Where(p => p.Name == name);
    }
    // sort depending on parameter
    if (sortByName) {
        result = result.OrderBy(p => p.Name);
    }
    else {
        result = result.OrderBy(p => p.Age);
    }
    // query will be executed when you enumerate the IQueryable
    return result.ToArray();
