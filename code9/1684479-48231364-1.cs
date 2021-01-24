    public Person(string xmlString)
    {
          var obj = Deserialize(xmlString);
          
           switch (name)
                {
                    case "firstName" :
                        FirstName = value;
                        break;
                    case "lastName":
                        LastName = value;
                        break;
                    case "dateOfBirth":
                        DateOfBirth = DateTime.Parse(value);
                        break;
                    case "address":
                        Address = value;
                        break;
                }
    }
