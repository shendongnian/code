     // serialize your objects list and write the serialized string to a file:
     string serializedPersons = JsonConvert.SerializeObject(personsList);
     System.IO.File.WriteAllText(@"D:\path.txt", serializedPersons);
     .
     .
     // read your file and deserialize the json text:
     string personsFileText = System.IO.File.ReadAllText(@"D:\path.txt");
     var persons = JsonConvert.DeserializeObject<List<Person>>(personsFileText );
      
