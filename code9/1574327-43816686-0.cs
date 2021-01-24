    private ArrayList AuthorSeparate(List<string> authorName)
        {
            string surName = string.Empty;
            string initalName = string.Empty;
            string givenName = string.Empty;
            int j = 1;
            ArrayList authors = new ArrayList();
            for (int i = 0; i < authorName.Count; i++)
            {
                XElement Author = new XElement("author");
                Author.Add(new XAttribute("Seq", j));
                else
                {
                    char[] initalArray = splitedName[0].ToCharArray();
                    initalName = initalArray[0] + '.'.ToString();
                    surName = splitedName.LastOrDefault();
                    splitedName = splitedName.Reverse().Skip(1).Reverse().ToArray();
                    givenName = string.Join(" ", splitedName);
                }
    
                if (!string.IsNullOrEmpty(initalName))
                {
                    XElement InitalElement = new XElement("initials", initalName);
                    Author.Add(InitalElement);
                }
    
                if (!string.IsNullOrEmpty(surName))
                {
                    XElement SurnameElement = new XElement("surname", surName);
                    Author.Add(SurnameElement);
                }
    
                if (!string.IsNullOrEmpty(givenName))
                {
                    XElement GivenNameElement = new XElement("given-name", givenName);
                    Author.Add(GivenNameElement);
                }
              authors.Add(Author)
            }
        return authors;
           }
