      SalesInfo person = new SalesInfo();
    
      words = ParseCsvString(stringValue.Trim());
      person.ID = Int32.Parse(words[0]);
      person.Name = words[1];
      person.City = words[2];
      string senior = words[3]; 
      if (senior == "Y"){ person.Senior = true; }
      else { person.Senior = false; }
