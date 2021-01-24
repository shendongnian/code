    personList_age = personList.OrderBy
    (
        y => {
                 int age;
                 bool ok = int.TryParse(y.Age, out age);
                 return ok ? age : default(int)
             }
    ).ToList();
