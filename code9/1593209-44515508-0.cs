    string path = @"c:\MyData\person.txt";
    List<person> persons = FileReadAllLines(path)
        .Select(x=> new person
        {
            name = x.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries)[0],
            gender = x.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries)[1],
            city = x.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries)[2],
            age = int.Parse(x.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries)[3])
        })
        .ToList();
  
